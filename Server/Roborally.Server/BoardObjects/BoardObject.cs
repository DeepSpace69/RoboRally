using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roborally.Communication.ServerInterfaces;

namespace Roborally.Server.BoardObjects
{
    public class BoardObject : IBoardObject
    {
        public IPosition Position { get; set; }
    }
}