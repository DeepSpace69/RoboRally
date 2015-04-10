using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Roborally.Communication.Data.Tests
{
    /// <summary>The test class.</summary>
    public class BaseTestClass
    {
        [DataFieldAttribute(Code = 1, IsOptional = false)]
        public string StringProperty { get; set; }

        [DataFieldAttribute(Code = 2, IsOptional = false)]
        public int IntProperty { get; set; }
    }

}
