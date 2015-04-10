using System;
using System.Collections.Generic;


namespace Roborally.Communication.Data.DataContracts
{
    public class LoginParameters
    {        
        [DataField(Code = 101, IsOptional = false)]
        public string Login { get; set; }

        [DataField(Code = 102, IsOptional = false)]
        public string Password { get; set; }
    }
}
