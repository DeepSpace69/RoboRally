using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roborally.Communication.ServerInterfaces;

namespace Roborally.Server
{
    internal class RobotModelsManager
    {
         private static RobotModelsManager instance;

         private RobotModelsManager()
        {
            this.RobotModelsDatabase = new List<IRobotsModel>();
            this.InitForTest();
        }

        private IList<IRobotsModel> RobotModelsDatabase { get; set; }

        /// <summary>Gets the instance.</summary>
        public static RobotModelsManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RobotModelsManager();
                }

                return instance;
            }
        }

        /// <summary>The get all robot models.</summary>
        /// <returns>The <see cref="IList"/>.</returns>
        public IList<IRobotsModel> GetAllRobotModels()
        {
            return this.RobotModelsDatabase;
        }

        private void InitForTest()
        {
            this.RobotModelsDatabase.Add(new RobotModel(1, "First"));
            this.RobotModelsDatabase.Add(new RobotModel(2, "Second"));
        }
    }
}