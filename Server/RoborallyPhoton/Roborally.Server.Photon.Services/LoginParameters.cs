using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Photon.SocketServer;
using Photon.SocketServer.Rpc;

namespace Roborally.Server.Photon.Services
{
    public class LoginParameters : Operation
    {
        public LoginParameters(IRpcProtocol protocol, OperationRequest request)
            : base(protocol, request)
        {
        }

        [DataMember(Code = 101, IsOptional = false)]
        public string Login { get; set; }

        [DataMember(Code = 102, IsOptional = false)]
        public string Password { get; set; }
    }

}
