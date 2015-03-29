namespace Roborally.Server
{
    using System.Collections.Generic;

    using Roborally.Communication.ServerInterfaces;

    /// <summary>The robot models database.</summary>
    internal class RobotModelsDatabase
    {
        private static RobotModelsDatabase instance;

        private RobotModelsDatabase()
        {
            this.AllRobotModels = new List<IRobotsModel>();
            this.InitForTest();
        }

        private ICollection<IRobotsModel> AllRobotModels { get; set; }

        /// <summary>Gets the instance.</summary>
        public static RobotModelsDatabase Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RobotModelsDatabase();
                }

                return instance;
            }
        }

        /// <summary>The get all robot models.</summary>
        /// <returns>The <see cref="ICollection"/>.</returns>
        public ICollection<IRobotsModel> GetAllRobotModels()
        {
            return this.AllRobotModels;
        }

        private void InitForTest()
        {
            this.AllRobotModels.Add(new RobotModel(1, "First"));
            this.AllRobotModels.Add(new RobotModel(2, "Second"));
        }
    }
}