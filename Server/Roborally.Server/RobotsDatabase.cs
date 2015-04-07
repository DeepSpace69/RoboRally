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
            this.idCounter = 0;
            this.InitForTest();
        }

       private int idCounter;
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

        public IRobot GetRobotById(int id)
        {
            IRobot result = null;
            foreach (var item in AllRobots)
            {
                if (item.Id == id)
                {
                    result = item;
                }
                break;
            }
            //проверка на 2 одинаковых ИД?
            if (result == null)
            {
                throw new NullReferenceException();
            }
            return result;
        }

        private void InitForTest()
        {
            this.CreateRobot(1, "TestRobot1");
            this.CreateRobot(2, "TestRobot2");
        }

        public void CreateRobot(int modelId, string name)
        {
            if (this.NameIsOriginal(name))
	        {
                idCounter = idCounter + 1;
                //проверить на существующий ИД?
                this.AllRobots.Add(new Robot(idCounter, modelId, name));
	        }
            else
            {
                throw new ArgumentException();
            }         
        }

       private bool NameIsOriginal(string name)
       {
           bool result = true;
           foreach (var item in this.AllRobots)
           {
               if (item.Name == name )
               {
                   result = false;
               }
           }
           return result;
       }

    }
}