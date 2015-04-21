using System.Runtime.Serialization;
using Roborally.Communication.ServerInterfaces;

namespace Roborally.Communication.Data.DataContracts
{
    /// <summary>The TestClass robot.</summary>
    
    public class TestClassRobot : IRobot
    {
        /// <summary>Gets the id.</summary>
        
        public int Id { get; set; }

        /// <summary>Gets the model id.</summary>
        
        public int ModelId { get; set; }

        /// <summary>Gets the name.</summary>
        
        public string Name { get; set; }
    }
}
