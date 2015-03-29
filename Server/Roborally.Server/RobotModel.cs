using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roborally.Server
{
    using Roborally.Communication.ServerInterfaces;

    internal class RobotModel : IRobotsModel
    {
        public RobotModel(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public string Name { get; private set; }
        public int Id { get; private set; }


    }



}
