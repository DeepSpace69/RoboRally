using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Roborally.Communication.ServerInterfaces;

namespace Roborally.Communication.Data.DataContracts
{
    public class PhotonRegister : IRegister
    {
        public string ID { get; set; }

        public IOrderCard Content { get; set; }

        public bool IsAvailable { get; set; }
    }
}
