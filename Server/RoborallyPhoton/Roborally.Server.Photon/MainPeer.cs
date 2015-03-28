namespace Roborally.Server.Photon
{
    using System;
    using global::Photon.SocketServer;
    using PhotonHostRuntimeInterfaces;
    using Roborally.Communication.ServerInterfaces;


    /// <summary>The main peer.</summary>
    public partial class MainPeer : PeerBase
    {
        private static readonly object syncRoot = new object();

        private readonly IMainService mainService;

        /// <summary>Initializes a new instance of the <see cref="MainPeer"/> class.</summary>
        /// <param name="protocol">The protocol.</param>
        /// <param name="unmanagedPeer">The unmanaged peer.</param>
        /// <param name="mainService">The main service.</param>
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

        private void OnBroadcastMessage(MainPeer peer, EventData @event, SendParameters sendParameters)
        {
            if (peer != this)
            {
                this.SendEvent(@event, sendParameters);
            }
        }
    }
}