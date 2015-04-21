using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

using Roborally.Communication.ServerInterfaces;

namespace Roborally.Communication.Data.DataContracts
{
    
    public class TestClassPosition : IPosition
    {
        
        public int X { get; set; }

        
        public int Y { get; set; }
    }
}
