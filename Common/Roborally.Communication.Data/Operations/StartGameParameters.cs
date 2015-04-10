using System;
using System.Collections.Generic;


namespace Roborally.Communication.Data.DataContracts
{
    public class StartGameParameters
    {       
        [DataField(Code = 101, IsOptional = false)]
        public int RobotId { get; set; }

        [DataField(Code = 102, IsOptional = false)]
        public int MapId { get; set; }

        [DataField(Code = 103, IsOptional = false)]
        public int NumberOfPlayers { get; set; }
    }
}
