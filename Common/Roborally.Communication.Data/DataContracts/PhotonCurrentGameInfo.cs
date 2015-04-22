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
    [DataContract(Namespace = "http://schemas.datacontract.org/2004/07/Roborally.Communication.ServerInterfaces")]
    public class PhotonCurrentGameInfo : ICurrentGameInfo
    {
        [DataMember]
        public IBoard Board { get; set; }

        [DataMember]
        public GameStateEnum CurrentState { get; set; }

        [DataMember]
        public IList<IGameRobot> GameRobots { get; set; }

        [DataMember]
        public IList<IRegister> Registers { get; set; }
    }
}
