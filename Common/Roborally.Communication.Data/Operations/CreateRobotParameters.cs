using System;
using System.Collections.Generic;


namespace Roborally.Communication.Data.DataContracts
{
    public class CreateRobotParameters
    {
        [DataField(Code = 101, IsOptional = false)]
        public string Name { get; set; }

        [DataField(Code = 102, IsOptional = false)]
        public int ModelId { get; set; }
    }
}
