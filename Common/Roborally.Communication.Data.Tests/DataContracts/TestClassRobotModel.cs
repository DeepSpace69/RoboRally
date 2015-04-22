using System.Runtime.Serialization;

using Roborally.Communication.ServerInterfaces;

namespace Roborally.Communication.Data.DataContracts
{
    /// <summary>The TestClass robot model.</summary>
    
    public class TestClassRobotModel : IRobotsModel
    {
        /// <summary>Gets or sets the id.</summary>
        
        public int Id { get; set; }

        /// <summary>Gets or sets the name.</summary>
        
        public string Name { get; set; }
    }
}
