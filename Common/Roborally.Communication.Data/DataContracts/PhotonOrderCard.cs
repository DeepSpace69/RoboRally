using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Roborally.Communication.ServerInterfaces;

namespace Roborally.Communication.Data.DataContracts
{
    public class PhotonOrderCard:IOrderCard
    {
        public string ID { get;  set; }

        public int Energy { get;  set; }

        public int Speed { get;  set; }

        public MoveDirectionEnum Type { get;  set; }
    }
}
