using Photon.SocketServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roborally.Server.Photon
{
    public class RoborallyHost : ApplicationBase
    {
        protected override PeerBase CreatePeer(InitRequest initRequest)
        {
            return new MainPeer(initRequest.Protocol, initRequest.PhotonPeer, new MainService());
        }

        protected override void Setup()
        {
        }

        protected override void TearDown()
        {
        }
    }
}
