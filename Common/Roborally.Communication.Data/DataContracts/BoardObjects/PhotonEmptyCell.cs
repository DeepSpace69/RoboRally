﻿using System.Runtime.Serialization;
using Roborally.Communication.ServerInterfaces;

namespace Roborally.Communication.Data.DataContracts
{
    /// <summary>The photon empty cell.</summary>
    [DataContract(Namespace = "http://schemas.datacontract.org/2004/07/Roborally.Communication.ServerInterfaces")]
    public class PhotonEmptyCell : IEmptyCell
    {
        /// <summary>Gets the position.</summary>
        [DataMember]
        public IPosition Position { get; set; }
    }
}
