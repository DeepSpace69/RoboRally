using Photon.SocketServer;
using PhotonHostRuntimeInterfaces;

namespace Roborally.Server.Photon
{
    public class ChatPeer : PeerBase
    {
        public ChatPeer(IRpcProtocol protocol, IPhotonPeer unmanagedPeer)
            : base(protocol, unmanagedPeer)
        {
        }

        protected override void OnDisconnect(DisconnectReason disconnectCode, string reasonDetail)
        {
        }

        protected override void OnOperationRequest(OperationRequest operationRequest, SendParameters sendParameters)
        {
            var response = new OperationResponse(operationRequest.OperationCode);
            this.SendOperationResponse(response, sendParameters);
        }
    }
}