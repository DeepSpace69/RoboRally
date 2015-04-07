using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roborally.Communication.ServerInterfaces;

namespace Roborally.Server
{
    public class CurrentGameInfo : ICurrentGameInfo
    {
        public IBoard Board { get; set; }

        public GameStateEnum CurrentState { get; set; }

        public ICollection<IGameRobot> GameRobots { get; set; }

        public ICollection<IRegister> Registers { get; set; }
    }
}