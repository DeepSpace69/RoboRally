using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roborally.Communication.ServerInterfaces;

namespace Roborally.Server
{
    public class Board:IBoard
    {
        public IEnumerable<IBoardObject> BoardObjects { get; set; }

        public IMap Map { get; set; }
    }
}