using Roborally.Communication.ServerInterfaces;

namespace Roborally.Communication.Data.DataContracts
{
    using System.Runtime.Serialization;

    /// <summary>The TestClass map.</summary>
    
    public class TestClassMap : IMap
    {
        /// <summary>Gets the id.</summary>
        
        public int Id { get; set; }

        /// <summary>Gets the name.</summary>
        
        public string Name { get; set; }
    }
}
