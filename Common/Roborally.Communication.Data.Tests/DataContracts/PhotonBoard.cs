using System.Collections.Generic;
using System.Runtime.Serialization;

using Roborally.Communication.Data.DataContracts.BoardObjects;
using Roborally.Communication.ServerInterfaces;

namespace Roborally.Communication.Data.DataContracts
{
    /// <summary>The TestClass board.</summary>
    
    public class TestClassBoard : IBoard
    {
        
        public IEnumerable<IBoardObject> BoardObjects { get; set; }

        
        public IMap Map { get; set; }
    }
}
