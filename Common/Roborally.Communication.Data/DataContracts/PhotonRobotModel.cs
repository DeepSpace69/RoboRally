using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Roborally.Communication.ServerInterfaces;

namespace Roborally.Communication.Data.DataContracts
{
    public class PhotonRobotModel : IRobotsModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
