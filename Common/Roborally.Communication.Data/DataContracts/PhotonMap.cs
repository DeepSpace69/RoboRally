using Roborally.Communication.ServerInterfaces;

namespace Roborally.Communication.Data.DataContracts
{
    /// <summary>The photon map.</summary>
    public class PhotonMap : IMap
    {
        /// <summary>Gets the id.</summary>
        public int Id { get; set; }

        /// <summary>Gets the name.</summary>
        public string Name { get; set; }
    }
}
