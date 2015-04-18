using System.Runtime.Serialization;

using Roborally.Communication.ServerInterfaces;

namespace Roborally.Communication.Data.DataContracts
{
    /// <summary>The photon robot model.</summary>
    [DataContract]
    public class PhotonRobotModel : IRobotsModel
    {
        /// <summary>Gets or sets the id.</summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>Gets or sets the name.</summary>
        [DataMember]
        public string Name { get; set; }
    }
}
