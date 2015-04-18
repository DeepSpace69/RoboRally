using System.Runtime.Serialization;
using Roborally.Communication.ServerInterfaces;

namespace Roborally.Communication.Data.DataContracts
{
    /// <summary>The photon robot.</summary>
    [DataContract]
    public class PhotonRobot : IRobot
    {
        /// <summary>Gets the id.</summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>Gets the model id.</summary>
        [DataMember]
        public int ModelId { get; set; }

        /// <summary>Gets the name.</summary>
        [DataMember]
        public string Name { get; set; }
    }
}
