using Roborally.Communication.ServerInterfaces;

namespace Roborally.Communication.Data.DataContracts
{
    using System.Runtime.Serialization;

    /// <summary>The photon map.</summary>
   [DataContract(Namespace = "http://schemas.datacontract.org/2004/07/Roborally.Communication.ServerInterfaces")]
    public class PhotonMap : IMap
    {
        /// <summary>Gets the id.</summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>Gets the name.</summary>
        [DataMember]
        public string Name { get; set; }
    }
}
