using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roborally.Communication.ServerInterfaces;

namespace Roborally.Server
{
    public class Robot : IRobot
    {
        public Robot(int id, int modelid, string name)
        {
            this.Id = id;
            this.ModelId = modelid;
            this.Name = name;
        }

        public int Id { get; private set; }

        public int ModelId { get; private set; }

        public string Name { get; private set; }
    }
}