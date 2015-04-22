using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Roborally.Communication.Data.Tests.DataContracts.BoardObjects
{
    using Roborally.Communication.ServerInterfaces;

    public class TestClassLaser : ILaser
    {
        public IPosition Position { get; set; }

        public int Power { get; set; }
    }
}
