using System;
using Photon.SocketServer;
using PhotonHostRuntimeInterfaces;
using Roborally.Communication.ServerInterfaces;
using Roborally.Server.Photon.Data;
using Roborally.Server.Photon.Services;

namespace Roborally.Server.Photon
{
    public class MainPeer : PeerBase
    {
        private readonly IMainService mainService;

        private static readonly object syncRoot = new object();

        public MainPeer(IRpcProtocol protocol, IPhotonPeer unmanagedPeer, IMainService mainService)
            : base(protocol, unmanagedPeer)
        {
            this.mainService = mainService;
            lock (syncRoot)
            {
                BroadcastMessage += this.OnBroadcastMessage;
            }
        }

        private static event Action<MainPeer, EventData, SendParameters> BroadcastMessage;

        protected override void OnDisconnect(DisconnectReason disconnectCode, string reasonDetail)
        {
            lock (syncRoot)
            {
                BroadcastMessage -= this.OnBroadcastMessage;
            }
        }

        protected override void OnOperationRequest(OperationRequest operationRequest, SendParameters sendParameters)
        {
            var incoming = new LoginParameters(this.Protocol, operationRequest);

            if (incoming.IsValid)
            {
                var user = mainService.Login(incoming.Login, incoming.Password);
                var photonUser = new PhotonUser(user);
                var response = new OperationResponse(operationRequest.OperationCode, photonUser);
                this.SendOperationResponse(response, sendParameters);
            }
        }

        private void OnBroadcastMessage(MainPeer peer, EventData @event, SendParameters sendParameters)
        {
            if (peer != this)
            {
                this.SendEvent(@event, sendParameters);
            }
        }
    }
}