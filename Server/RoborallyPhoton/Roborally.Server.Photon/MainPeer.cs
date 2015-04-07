using System;

using global::Photon.SocketServer;
using PhotonHostRuntimeInterfaces;
using Roborally.Server.Photon.Interfaces;

namespace Roborally.Server.Photon
{
    /// <summary>The main peer.</summary>
    public class MainPeer : PeerBase
    {
        private static readonly object syncRoot = new object();

        private readonly IServiceRepository serviceRepository;

        /// <summary>Initializes a new instance of the <see cref="MainPeer"/> class.</summary>
        /// <param name="protocol">The protocol.</param>
        /// <param name="unmanagedPeer">The unmanaged peer.</param>
        /// <param name="serviceRepository">The main service.</param>
        public MainPeer(IRpcProtocol protocol, IPhotonPeer unmanagedPeer, IServiceRepository serviceRepository)
            : base(protocol, unmanagedPeer)
        {
            this.serviceRepository = serviceRepository;
            lock (syncRoot)
            {
                BroadcastMessage += this.OnBroadcastMessage;
            }
        }

        private static event Action<MainPeer, EventData, SendParameters> BroadcastMessage;

        /// <summary>The on disconnect.</summary>
        /// <param name="disconnectCode">The disconnect code.</param>
        /// <param name="reasonDetail">The reason detail.</param>
        protected override void OnDisconnect(DisconnectReason disconnectCode, string reasonDetail)
        {
            lock (syncRoot)
            {
                BroadcastMessage -= this.OnBroadcastMessage;
            }
        }

        /// <summary>The on operation request.</summary>
        /// <param name="operationRequest">The operation request.</param>
        /// <param name="sendParameters">The send parameters.</param>
        protected override void OnOperationRequest(OperationRequest operationRequest, SendParameters sendParameters)
        {
            var response = this.serviceRepository.Execute(operationRequest);
            this.SendOperationResponse(response, sendParameters);
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