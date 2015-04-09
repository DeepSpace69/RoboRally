using System;
using System.Collections.Generic;


namespace Roborally.Communication.Data.DataContracts
{
    public class StartGameParameters : SerializableMapBase
    {
        /// <summary>Initializes a new instance of the <see cref="StartGameParameters"/> class.</summary>
        public StartGameParameters()
        {            
        }

        /// <summary>Initializes a new instance of the <see cref="StartGameParameters"/> class.</summary>
        /// <param name="parameters">The parameters.</param>
        public StartGameParameters(Dictionary<byte, object> parameters)
            : base(parameters)
        {
        }

        [DataField(Code = 101, IsOptional = false)]
        public int RobotId { get; set; }

        [DataField(Code = 102, IsOptional = false)]
        public int MapId { get; set; }

        [DataField(Code = 103, IsOptional = false)]
        public int NumberOfPlayers { get; set; }
    }
}
