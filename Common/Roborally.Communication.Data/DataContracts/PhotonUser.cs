namespace Roborally.Communication.Data.DataContracts
{
    using System.Collections.Generic;

    using Roborally.Communication.ServerInterfaces;

    /// <summary>The photon user.</summary>
    public class PhotonUser : SerializableMapBase, IUser
    {
        public PhotonUser()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="PhotonUser"/> class.</summary>
        /// <param name="param">The param.</param>
        public PhotonUser(Dictionary<byte, object> param)
            : base(param)
        {
        }

        /// <summary>Gets or sets the id.</summary>
        [DataField(Code = 1, IsOptional = false)]
        public string ID { get; set; }

        /// <summary>Gets or sets the name.</summary>
        [DataField(Code = 2, IsOptional = false)]
        public string Name { get; set; }
    }
}