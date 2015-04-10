namespace Roborally.Communication.Data.DataContracts
{
    using System.Collections.Generic;

    using Roborally.Communication.ServerInterfaces;

    /// <summary>The photon user.</summary>
    public class PhotonUser : IUser
    {
        /// <summary>Gets or sets the id.</summary>
        [DataField(Code = 1, IsOptional = false)]
        public int ID { get; set; }

        /// <summary>Gets or sets the name.</summary>
        [DataField(Code = 2, IsOptional = false)]
        public string Name { get; set; }
    }
}