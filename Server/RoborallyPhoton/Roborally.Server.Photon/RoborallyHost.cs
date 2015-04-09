using Photon.SocketServer;

using Roborally.Server.Photon.Interfaces;
using Roborally.Server.Photon.Services;

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
            // TODO to IoC
            var repository = new RoborallyPhotonServiceRepository();

            this.CreateServices(repository);

            return new MainPeer(initRequest.Protocol, initRequest.PhotonPeer, repository);
        }

        private void CreateServices(IServiceRepository repository)
        {
            var mainService = new MainService();
            var menuService = new RoborallyPhotonMenuServices(repository, mainService);
            var gameService = new RoborallyPhotonGameServices(repository, mainService);
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
