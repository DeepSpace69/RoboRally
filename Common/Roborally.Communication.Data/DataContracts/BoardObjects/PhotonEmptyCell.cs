using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

using Roborally.Communication.ServerInterfaces;

namespace Roborally.Communication.Data.DataContracts.BoardObjects
{
    public class PhotonEmptyCell : IEmptyCell
    {
        public IPosition Position { get; set; }
    }
}
