using System.Runtime.Serialization;
using Roborally.Communication.ServerInterfaces;

namespace Roborally.Communication.Data.Tests.DataContracts.BoardObjects
{
    [DataContract(Namespace = "http://schemas.datacontract.org/2004/07/Roborally.Communication.ServerInterfaces")]
    public class PhotonLaser : ILaser
    {
        [DataMember]
        public IPosition Position { get; set; }

        [DataMember]
        public int Power { get; set; }
    }
}
