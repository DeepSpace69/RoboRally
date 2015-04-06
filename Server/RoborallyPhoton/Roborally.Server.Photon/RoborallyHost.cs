using Photon.SocketServer;

namespace Roborally.Server.Photon
{
    /// <summary>The roborally host.</summary>
    public class RoborallyHost : ApplicationBase
    {
        /// <summary>The create peer.</summary>
        /// <param name="initRequest">The init request.</param>
        /// <returns>The <see cref="PeerBase"/>.</returns>
        protected override PeerBase CreatePeer(InitRequest initRequest)
        {
            return new MainPeer(initRequest.Protocol, initRequest.PhotonPeer, new MainService());
        }

        /// <summary>The setup.</summary>
        protected override void Setup()
        {
        }

        /// <summary>The tear down.</summary>
        protected override void TearDown()
        {
        }
    }
}
