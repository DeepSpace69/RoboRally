using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

using Roborally.Communication.ServerInterfaces;

namespace Roborally.Communication.Data.DataContracts
{
    [DataContract]
    public class PhotonGameRobot : IGameRobot
    {
        [DataMember]
        public IPosition Position { get; set; }

        [DataMember]
        public DirectionEnum CurrentDirection { get; set; }

        [DataMember]
        public int HealthPoint { get; set; }

        [DataMember]
        public bool IsPowerDown { get; set; }

        [DataMember]
        public int LifeAmount { get; set; }

        [DataMember]
        public int RobotId { get; set; }

        [DataMember]
        public IRobotsModel RobotsModel { get; set; }

        [DataMember]
        public string Name { get; set; }
    }
}
