using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roborally.Communication.ServerInterfaces;

namespace Roborally.Server
{
   internal class RobotsDatabase
    {
       private static RobotsDatabase instance;

       private RobotsDatabase()
        {
            this.AllRobots = new List<IRobot>();
            this.InitForTest();
        }

        private ICollection<IRobot> AllRobots { get; set; }

        /// <summary>Gets the instance.</summary>
        public static RobotsDatabase Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RobotsDatabase();
                }

                return instance;
            }
        }

        /// <summary>The get all robot models.</summary>
        /// <returns>The <see cref="ICollection"/>.</returns>
        public ICollection<IRobot> GetRobots()
        {
            return this.AllRobots;
        }

        private void InitForTest()
        {
            this.AllRobots.Add(new Robot(1, 1, "TestRobot"));
            this.AllRobots.Add(new Robot(2, 2, "TestRobot2"));
        }

    }
}