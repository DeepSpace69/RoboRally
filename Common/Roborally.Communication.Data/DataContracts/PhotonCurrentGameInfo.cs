using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

using Roborally.Communication.ServerInterfaces;

namespace Roborally.Communication.Data.DataContracts
{
    /// <summary>The photon current game info.</summary>
    public class PhotonCurrentGameInfo : ICurrentGameInfo
    {
        public IBoard Board { get; set; }

        public GameStateEnum CurrentState { get; set; }

        public IEnumerable<IGameRobot> GameRobots { get; set; }

        public IEnumerable<IRegister> Registers { get; set; }
    }
}
