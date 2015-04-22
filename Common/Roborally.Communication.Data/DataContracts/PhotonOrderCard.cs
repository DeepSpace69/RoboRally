using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

using Roborally.Communication.ServerInterfaces;

namespace Roborally.Communication.Data.DataContracts
{
    [DataContract(Namespace = "http://schemas.datacontract.org/2004/07/Roborally.Communication.ServerInterfaces")]
    public class PhotonOrderCard : IOrderCard
    {
        [DataMember]
        public string ID { get; set; }

        [DataMember]
        public int Energy { get; set; }

        [DataMember]
        public int Speed { get; set; }

        [DataMember]
        public MoveDirectionEnum Type { get; set; }
    }
}
