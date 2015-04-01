using System;
using System.Collections.Generic;


namespace Roborally.Communication.Data.DataContracts
{
    public class CreateRobotParameters : SerializableMapBase
    {
        public const int OperationCode = 102;

        public CreateRobotParameters()
        { }

        /// <summary>Initializes a new instance of the <see cref="LoginParameters"/> class.</summary>
        /// <param name="parameters">The parameters.</param>
        public CreateRobotParameters(Dictionary<byte, object> parameters)
            : base(parameters)
        {
        }

        [DataField(Code = 101, IsOptional = false)]
        public string Name { get; set; }

        [DataField(Code = 102, IsOptional = false)]
        public string ModelId { get; set; }
    }

}
