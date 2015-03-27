using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Photon.SocketServer;
using Photon.SocketServer.Rpc;
using Roborally.Communication.ServerInterfaces;

namespace Roborally.Server.Photon.Data
{
    public class PhotonUser : IUser
    {        
        public PhotonUser(IUser user)
        {
            this.ID = user.ID;
            this.Name = user.Name;
        }

        [DataMember(Code = 101, IsOptional = false)]
        public string ID { get; set; }

        [DataMember(Code = 102, IsOptional = false)]
        public string Name { get; set; }
    }
}
