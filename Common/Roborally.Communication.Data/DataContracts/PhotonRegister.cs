using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

using Roborally.Communication.ServerInterfaces;

namespace Roborally.Communication.Data.DataContracts
{
    [DataContract(Namespace = "http://schemas.datacontract.org/2004/07/Roborally.Communication.ServerInterfaces")]
    public class PhotonRegister : IRegister
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public IOrderCard Content { get; set; }

        [DataMember]
        public bool IsAvailable { get; set; }
    }
}
