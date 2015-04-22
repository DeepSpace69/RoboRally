using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

using Roborally.Communication.ServerInterfaces;

namespace Roborally.Communication.Data.DataContracts
{
    /// <summary>The TestClass current game info.</summary>
    
    public class TestClassCurrentGameInfo : ICurrentGameInfo
    {
        
        public IBoard Board { get; set; }

        
        public GameStateEnum CurrentState { get; set; }

        
        public IList<IGameRobot> GameRobots { get; set; }

        
        public IList<IRegister> Registers { get; set; }
    }
}
