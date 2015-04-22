using System.Runtime.Serialization;
using Roborally.Communication.ServerInterfaces;

namespace Roborally.Communication.Data.DataContracts.BoardObjects
{
    /// <summary>The TestClass empty cell.</summary>
    
    public class TestClassEmptyCell : IEmptyCell
    {
        /// <summary>Gets the position.</summary>
        
        public IPosition Position { get; set; }
    }
}
