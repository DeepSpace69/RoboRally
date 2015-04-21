using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

using Roborally.Communication.ServerInterfaces;

namespace Roborally.Communication.Data.DataContracts
{
    
    public class TestClassGameRobot : IGameRobot
    {
        
        public IPosition Position { get; set; }

        
        public DirectionEnum CurrentDirection { get; set; }

        
        public int HealthPoint { get; set; }

        
        public bool IsPowerDown { get; set; }

        
        public int LifeAmount { get; set; }

        
        public int RobotId { get; set; }

        
        public IRobotsModel RobotsModel { get; set; }

        
        public string Name { get; set; }
    }
}
