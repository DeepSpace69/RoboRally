using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roborally.Communication.ServerInterfaces;

namespace Roborally.Server
{
    internal class RobotsManager
    {
        private static RobotsManager instance;

        private RobotsManager()
        {
            this.RobotsDatabase = new List<IRobot>();
            this.idCounter = 0;
            this.InitForTest();
        }

       private int idCounter;
        private ICollection<IRobot> RobotsDatabase { get; set; }

        /// <summary>Gets the instance.</summary>
        public static RobotsManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RobotsManager();
                }

                return instance;
            }
        }

        /// <summary>The get all robot models.</summary>
        /// <returns>The <see cref="ICollection"/>.</returns>
        public ICollection<IRobot> GetRobots()
        {
            return this.RobotsDatabase;
        }

        public IRobot GetRobotById(int id)
        {
            IRobot result = null;
            foreach (var item in RobotsDatabase)
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
                this.RobotsDatabase.Add(new Robot(idCounter, modelId, name));
	        }
            else
            {
                throw new ArgumentException();
            }         
        }

       private bool NameIsOriginal(string name)
       {
           bool result = true;
           foreach (var item in this.RobotsDatabase)
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