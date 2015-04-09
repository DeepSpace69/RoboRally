using System.Collections.Generic;

using Roborally.Communication.ServerInterfaces;

namespace Roborally.Communication.Data.DataContracts
{
    /// <summary>The photon board.</summary>
    public class PhotonBoard : IBoard
    {
        public IEnumerable<IBoardObject> BoardObjects { get; set; }

        public IMap Map { get; set; }
    }
}
