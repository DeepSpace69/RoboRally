using System.Collections.Generic;
using System.Runtime.Serialization;

using Roborally.Communication.ServerInterfaces;

namespace Roborally.Communication.Data.DataContracts
{
    /// <summary>The photon board.</summary>
    [DataContract(Namespace = "http://schemas.datacontract.org/2004/07/Roborally.Communication.ServerInterfaces")]
    public class PhotonBoard : IBoard
    {
        [DataMember]
        public IList<IBoardObject> BoardObjects { get; set; }

        [DataMember]
        public IMap Map { get; set; }

        [OnDeserialized]
        public void OnSerializingMethod(StreamingContext context)
        {

        }
    }
}
