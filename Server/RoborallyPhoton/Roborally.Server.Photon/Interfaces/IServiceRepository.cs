using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Photon.SocketServer;

namespace Roborally.Server.Photon.Interfaces
{
    /// <summary>The ServiceRepository interface.</summary>
    public interface IServiceRepository
    {
        /// <summary>The execute.</summary>
        /// <param name="operationRequest">The operation request.</param>
        /// <returns>The <see cref="OperationResponse"/>.</returns>
        OperationResponse Execute(OperationRequest operationRequest);

        /// <summary>The register.</summary>
        /// <param name="code">The code.</param>
        /// <param name="service">The service.</param>
        void Register(byte code, Func<OperationRequest, OperationResponse> service);
    }
}
