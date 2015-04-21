using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

using Roborally.Communication.ServerInterfaces;

namespace Roborally.Communication.Data.DataContracts
{
    
    public class TestClassRegister : IRegister
    {
        
        public int ID { get; set; }

        
        public IOrderCard Content { get; set; }

        
        public bool IsAvailable { get; set; }
    }
}
