using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;

using Roborally.Communication.ServerInterfaces;

namespace Roborally.Communication.Data.DataContracts
{
    /// <summary>The photon current game info.</summary>
    [DataContract]
    public class PhotonCurrentGameInfo : ICurrentGameInfo
    {
        [DataMember]
        public IBoard Board { get; set; }

        [DataMember]
        public GameStateEnum CurrentState { get; set; }

        [DataMember]
        public IEnumerable<IGameRobot> GameRobots { get; set; }

        [DataMember]
        public IEnumerable<IRegister> Registers { get; set; }
    }
}
