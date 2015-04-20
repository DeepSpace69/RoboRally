using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;

using Roborally.Communication.ServerInterfaces;

namespace Roborally.Communication.Data.DataContracts.BoardObjects
{
    [DataContract]
    public class PhotonEmptyCell : IEmptyCell
    {
        [DataMember]
        public IPosition Position { get; set; }
    }
}
