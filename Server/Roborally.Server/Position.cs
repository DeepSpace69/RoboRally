using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roborally.Communication.ServerInterfaces;

namespace Roborally.Server
{
   public class Position:IPosition
    {
       public int X { get; set; }
       public int Y { get; set; }
    }
}