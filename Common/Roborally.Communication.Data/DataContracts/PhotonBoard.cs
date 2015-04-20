using System.Collections.Generic;
using System.Runtime.Serialization;

using Roborally.Communication.ServerInterfaces;

namespace Roborally.Communication.Data.DataContracts
{
    /// <summary>The photon board.</summary>
    [DataContract]
    public class PhotonBoard : IBoard
    {
        [DataMember]
        public IEnumerable<IBoardObject> BoardObjects { get; set; }

        [DataMember]
        public IMap Map { get; set; }
    }
}
