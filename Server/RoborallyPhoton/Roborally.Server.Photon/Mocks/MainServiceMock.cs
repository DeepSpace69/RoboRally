using System.Collections.Generic;

using Roborally.Communication.Data.DataContracts;
using Roborally.Communication.Data.DataContracts.BoardObjects;
using Roborally.Communication.ServerInterfaces;

namespace Roborally.Server.TestClass.Mocks
{
    using Roborally.Communication.Data.Tests.DataContracts.BoardObjects;

    /// <summary>The main service mock.</summary>
    public class MainServiceMock : IMainService
    {
        #region Server API

        /// <summary>Gets information about what happens after performing actions of board objects.</summary>
        /// <param name="robots">The robots with new position and status.</param>
        public void BoardActions(IList<IGameRobot> robots)
        {
        }

        /// <summary>Create new robot for current user.</summary>
        /// <param name="robotModelId">The robot's model id.</param>
        /// <param name="name">The name of robot.</param>
        public void CreateRobot(int robotModelId, string name)
        {
        }

        /// <summary>Get cards for current turn.</summary>
        /// <returns>Collection of card for current turn.</returns>
        public IList<IOrderCard> GetCards()
        {
            return new List<IOrderCard>();
        }

        /// <summary>Get current game info. Call each new turn.</summary>
        /// <returns>The object that represents all details about current game.</returns>
        public ICurrentGameInfo GetCurrentGameInfo()
        {
            return this.CreateTestClassCurrentGameInfo();
        }

        /// <summary>Get available maps for playing.</summary>
        /// <returns>Available maps for playing.</returns>
        public IList<IMap> GetMaps()
        {
            return new List<IMap>()
                       {
                           new TestClassMap() { Id = 1, Name = "Test map 1" },
                           new TestClassMap() { Id = 2, Name = "Test map 2" }
                       };
        }

        /// <summary>Get robots of current user, that can play.</summary>
        /// <returns>Robots that can play.</returns>
        public IList<IRobot> GetMyRobots()
        {
            return new List<IRobot>()
                       {
                           new TestClassRobot() { Id = 1, ModelId = 1, Name = "Test robot 1" },
                           new TestClassRobot() { Id = 2, ModelId = 2, Name = "Test robot 2" },
                       };
        }

        /// <summary>Get ratings.</summary>
        /// <returns>Information about race, places, kills, etc.</returns>
        public IList<IRating> GetRatings()
        {
            return new List<IRating>();
        }

        /// <summary>Gets robots models.</summary>
        /// <returns>Available robots models.</returns>
        public IList<IRobotsModel> GetRobotsModels()
        {
            return new List<IRobotsModel>()
                       {
                           new TestClassRobotModel() { Id = 1, Name = "Test Model 1" },
                           new TestClassRobotModel() { Id = 2, Name = "Test Model 2" }
                       };
        }

        /// <summary>Login into game.</summary>
        /// <param name="login">User's login.</param>
        /// <param name="password">User's password.</param>
        /// <returns>The <see cref="IUser"/>.</returns>
        public IUser Login(string login, string password)
        {
            return new User(1, "TestUser");
        }

        /// <summary>Gets information about what happens after performing moving robots.</summary>
        /// <param name="robotId">Current players robot id.</param>
        /// <param name="robots">The robots.</param>
        public void MoveRobots(int robotId, IList<IGameRobot> robots)
        {
        }

        /// <summary>Start game.</summary>
        /// <param name="robotId">The robot id.</param>
        /// <param name="mapId">The map id.</param>
        /// <param name="numberOfPlayers">The number of players.</param>
        public void Play(int robotId, int mapId, int numberOfPlayers)
        {
        }

        /// <summary>Performing power down - skip last turn.</summary>
        public void PowerDown()
        {
        }

        /// <summary>Place order cards into registers and send this info on server.</summary>
        /// <param name="registers">The registers with cards.</param>
        public void SetupRegisters(IList<IRegister> registers)
        {
        }

        /// <summary>Show content of current registers of all players.</summary>
        /// <param name="registers">Registers with their cards.</param>
        public void ShowRegister(IDictionary<string, IRegister> registers)
        {
        }

        #endregion

        #region CreateTestClassCurrentGameInfo

        private TestClassCurrentGameInfo CreateTestClassCurrentGameInfo()
        {
            var result = new TestClassCurrentGameInfo();

            result.Board = this.CreateBoard();
            result.CurrentState = GameStateEnum.DrawCards;
            result.GameRobots = this.CreateRobots();
            result.Registers = this.CreateRegisters();
            return result;
        }

        private IList<IRegister> CreateRegisters()
        {
            var register1 = new TestClassRegister();
            register1.ID = 1;
            register1.IsAvailable = false;
            register1.Content = new TestClassOrderCard() { Energy = 10, ID = "1", Speed = 1, Type = MoveDirectionEnum.MoveForward };

            var register2 = new TestClassRegister();
            register2.ID = 2;
            register2.IsAvailable = true;
            register2.Content = new TestClassOrderCard() { Energy = 20, ID = "2", Speed = 0, Type = MoveDirectionEnum.TurnLeft };

            var register3 = new TestClassRegister();
            register3.ID = 3;
            register3.IsAvailable = true;

            var register4 = new TestClassRegister();
            register4.ID = 4;
            register4.IsAvailable = true;

            var register5 = new TestClassRegister();
            register5.ID = 5;
            register5.IsAvailable = true;

            var result = new List<IRegister>() { register1, register2, register3, register4, register5 };
            return result;
        }

        private IList<IGameRobot> CreateRobots()
        {
            var robot = new TestClassGameRobot();
            robot.CurrentDirection = DirectionEnum.Up;
            robot.HealthPoint = 9;
            robot.IsPowerDown = false;
            robot.LifeAmount = 3;
            robot.Name = "Megatron";
            robot.Position = new TestClassPosition() { X = 1, Y = 2 };
            robot.RobotId = 1;
            robot.RobotsModel = new TestClassRobotModel() { Id = 1, Name = "TerminatorRobotModel" };
            var result = new List<IGameRobot>() { robot };
            return result;
        }

        private IBoard CreateBoard()
        {
            var result = new TestClassBoard();
            result.BoardObjects = new List<IBoardObject>()
                                      {
                                          new TestClassEmptyCell() { Position = new TestClassPosition() { X = 0, Y = 0 } },
                                          new TestClassEmptyCell() { Position = new TestClassPosition() { X = 1, Y = 0 } },
                                          new TestClassEmptyCell() { Position = new TestClassPosition() { X = 2, Y = 0 } },
                                          new TestClassEmptyCell() { Position = new TestClassPosition() { X = 0, Y = 1 } },
                                          new TestClassEmptyCell() { Position = new TestClassPosition() { X = 1, Y = 1 } },
                                          new TestClassEmptyCell() { Position = new TestClassPosition() { X = 2, Y = 1 } },
                                          new TestClassEmptyCell() { Position = new TestClassPosition() { X = 0, Y = 2 } },
                                          new TestClassEmptyCell() { Position = new TestClassPosition() { X = 1, Y = 2 } },
                                          new TestClassEmptyCell() { Position = new TestClassPosition() { X = 2, Y = 2 } },
                                          new TestClassLaser() { Position = new TestClassPosition() { X = 1, Y = 3 }, Power = 5 }
                                      };
            return result;
        }

        #endregion

    }
}
