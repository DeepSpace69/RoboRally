using System;
using System.Collections.Generic;

using Photon.SocketServer;

using Roborally.Server.Photon.Interfaces;

namespace Roborally.Server.Photon.Services
{
    /// <summary>The roborally photon service repository.</summary>
    public class RoborallyPhotonServiceRepository : IServiceRepository
    {
        private readonly Dictionary<byte, Func<OperationRequest, OperationResponse>> operationsDictionary =
            new Dictionary<byte, Func<OperationRequest, OperationResponse>>();

        /// <summary>The execute.</summary>
        /// <param name="operationRequest">The operation request.</param>
        /// <returns>The <see cref="OperationResponse"/>.</returns>
        public OperationResponse Execute(OperationRequest operationRequest)
        {
            Func<OperationRequest, OperationResponse> operation;
            var isRegisteredOperation = this.operationsDictionary.TryGetValue(operationRequest.OperationCode, out operation);

            var response = isRegisteredOperation ?
                operation(operationRequest) :
                new OperationResponse(operationRequest.OperationCode, new Dictionary<byte, object>() { { 1, "Unknown operation" } });

            return response;
        }

        /// <summary>The register.</summary>
        /// <param name="code">The code.</param>
        /// <param name="service">The service.</param>
        public void Register(byte code, Func<OperationRequest, OperationResponse> service)
        {
            this.operationsDictionary.Add(code, service);
        }
    }
}
