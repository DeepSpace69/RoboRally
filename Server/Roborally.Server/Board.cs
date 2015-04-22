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
        public IList<IBoardObject> BoardObjects { get; set; }

        public IMap Map { get; set; }
    }
}