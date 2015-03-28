using System;
using System.Collections.Generic;


namespace Roborally.Communication.Data.DataContracts
{
    public class LoginParameters : SerializableMapBase
    {
        public const int OperationCode = 101;

        public LoginParameters()
        { }

        /// <summary>Initializes a new instance of the <see cref="LoginParameters"/> class.</summary>
        /// <param name="parameters">The parameters.</param>
        public LoginParameters(Dictionary<byte, object> parameters)
            : base(parameters)
        {
        }

        [DataField(Code = 101, IsOptional = false)]
        public string Login { get; set; }

        [DataField(Code = 102, IsOptional = false)]
        public string Password { get; set; }
    }

}
