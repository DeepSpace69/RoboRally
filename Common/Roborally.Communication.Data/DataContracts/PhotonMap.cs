using Roborally.Communication.ServerInterfaces;

namespace Roborally.Communication.Data.DataContracts
{
    using System.Runtime.Serialization;

    /// <summary>The photon map.</summary>
    [DataContract]
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
