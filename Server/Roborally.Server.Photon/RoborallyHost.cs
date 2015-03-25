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
            return new ChatPeer(initRequest.Protocol, initRequest.PhotonPeer);
        }

        protected override void Setup()
        {
        }

        protected override void TearDown()
        {
        }
    }
}
