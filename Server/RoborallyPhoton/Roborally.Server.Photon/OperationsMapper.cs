using System.Collections.Generic;
using global::Photon.SocketServer;
using Roborally.Communication.Data.DataContracts;

namespace Roborally.Server.Photon
{
    /// <summary>The main peer.</summary>
    public partial class MainPeer
    {
        private readonly Dictionary<byte, OperationRequestDelegate> operationsDictionary = new Dictionary<byte, OperationRequestDelegate>();

        private delegate void OperationRequestDelegate(OperationRequest operationRequest, SendParameters sendParameters);

        /// <summary>The on operation request.</summary>
        /// <param name="operationRequest">The operation request.</param>
        /// <param name="sendParameters">The send parameters.</param>
        protected override void OnOperationRequest(OperationRequest operationRequest, SendParameters sendParameters)
        {
            OperationRequestDelegate operation;
            var success = this.operationsDictionary.TryGetValue(operationRequest.OperationCode, out operation);

            if (success)
            {
                operation(operationRequest, sendParameters);
            }
            else
            {
                var response = new OperationResponse(operationRequest.OperationCode, new Dictionary<byte, object>() { { 1, "Unknown operation" } });
                this.SendOperationResponse(response, sendParameters);
            }
        }

        private void Init()
        {
            this.operationsDictionary.Add(LoginParameters.OperationCode, this.Login);
            this.operationsDictionary.Add(CreateRobotParameters.OperationCode, this.CreateRobot);
            this.operationsDictionary.Add(103, this.GetMyRobots);
        }
    }
}