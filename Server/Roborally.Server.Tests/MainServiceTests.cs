using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Roborally.Server.Tests
{
    using System;

    using Roborally.Communication.ServerInterfaces;

    [TestClass]
    public class MainServiceTests
    {
        private MainService mainService;

        [TestInitialize]
        public void Init()
        {
            this.mainService = new MainService();
        }

        #region MenuTests

        [TestMethod]
        public void Login_ExistingUser_Success()
        {
            var user = this.mainService.Login("1", "1");

            Assert.AreEqual(1, user.ID);
        }

        [TestMethod]
        public void GetRobotsModels_RobotsModelFirstMustExist()
        {
            var models = this.mainService.GetRobotsModels();

            Assert.IsNotNull(models);
            Assert.IsTrue(models.Count() > 0);
            Assert.IsTrue(models.Any(p => p.Id == 1));
        }

        [TestMethod]
        public void GetMyRobots_CorrectRobots()
        {
            this.mainService.Login("1", "1");
            var myRobots = this.mainService.GetMyRobots();

            var myRobotsIds = myRobots.Select(p => p.Id).ToList();

            CollectionAssert.AllItemsAreUnique(myRobotsIds);
        }

        [TestMethod]
        public void CreateRobot_TestWithFirstModel_RobotCreated()
        {
            this.mainService.Login("1", "1");

            var randName = Guid.NewGuid().ToString();

            this.mainService.CreateRobot(1, randName);
            var myRobots = this.mainService.GetMyRobots();

            Assert.IsTrue(myRobots.Any(p => p.Name == randName && p.ModelId == 1));
        }

        [TestMethod]
        public void GetMaps_AnyMapsExist()
        {
            var mapsCollection = this.mainService.GetMaps();

            Assert.IsTrue(mapsCollection.Count() > 0);
            Assert.IsTrue(mapsCollection.Any(p => p.Id == 1));
        }

        #endregion

        [TestMethod]
        public void Play_WithNewCreatedRobot_GameStarted()
        {
            // Expected map is 3x3 cell with robot at the (1,2):
            ////   ______
            ////  |_|_|_|
            ////  |_|_|_|
            ////  |_|R|_|
            ////
            ////

            this.SetupGame();

            var gameInfo = this.mainService.GetCurrentGameInfo();

            // Other
            Assert.AreEqual(GameStateEnum.DrawCards, gameInfo.CurrentState);
            Assert.IsNotNull(gameInfo);
            Assert.AreEqual(5, gameInfo.Registers.Count());

            // Registers
            CollectionAssert.AllItemsAreUnique(gameInfo.Registers.Select(p => p.ID).ToList());
            Assert.IsTrue(gameInfo.Registers.All(p => p.IsAvailable));
            Assert.IsTrue(gameInfo.Registers.All(p => p.Content == null));

            // Robots
            Assert.AreEqual(1, gameInfo.GameRobots.Count());
            var myRobot = gameInfo.GameRobots.FirstOrDefault();
            Assert.IsNotNull(myRobot);
            Assert.AreEqual(DirectionEnum.Up, myRobot.CurrentDirection);
            Assert.AreEqual(9, myRobot.HealthPoint);
            Assert.IsFalse(myRobot.IsPowerDown);
            Assert.AreEqual(3, myRobot.LifeAmount);
            Assert.AreEqual(1, myRobot.Position.X);
            Assert.AreEqual(2, myRobot.Position.Y);
            Assert.AreEqual(1, myRobot.RobotsModel.Id);
            Assert.AreEqual("TestRobot", myRobot.Name);

            // Map
            Assert.AreEqual(1, gameInfo.Board.Map.Id);
            Assert.AreEqual(9, gameInfo.Board.BoardObjects);
            Assert.IsTrue(gameInfo.Board.BoardObjects.All(p => p is IEmptyCell));
            Assert.IsTrue(gameInfo.Board.BoardObjects.Any(p => p.Position.X == 0 && p.Position.Y == 0));
            Assert.IsTrue(gameInfo.Board.BoardObjects.Any(p => p.Position.X == 1 && p.Position.Y == 0));
            Assert.IsTrue(gameInfo.Board.BoardObjects.Any(p => p.Position.X == 2 && p.Position.Y == 0));
            Assert.IsTrue(gameInfo.Board.BoardObjects.Any(p => p.Position.X == 0 && p.Position.Y == 1));
            Assert.IsTrue(gameInfo.Board.BoardObjects.Any(p => p.Position.X == 1 && p.Position.Y == 1));
            Assert.IsTrue(gameInfo.Board.BoardObjects.Any(p => p.Position.X == 2 && p.Position.Y == 1));
            Assert.IsTrue(gameInfo.Board.BoardObjects.Any(p => p.Position.X == 0 && p.Position.Y == 2));
            Assert.IsTrue(gameInfo.Board.BoardObjects.Any(p => p.Position.X == 1 && p.Position.Y == 2));
            Assert.IsTrue(gameInfo.Board.BoardObjects.Any(p => p.Position.X == 2 && p.Position.Y == 2));
        }

        [TestMethod]
        public void GetCards_AllCards_NineCardsWithEnergy()
        {
            this.SetupGame();
            var cards = this.mainService.GetCards();

            Assert.AreEqual(9, cards.Count());
            Assert.IsTrue(cards.All(p => p.Energy > 0 && p.Energy < 1000));
            Assert.IsTrue(cards.All(p => p.Type != MoveDirectionEnum.None));
        }

        #region SetupRegisters

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void SetupRegisters_SameCardInSeveralRegisters_Error()
        {
            this.SetupGame();
            var registers = this.mainService.GetCurrentGameInfo().Registers.ToList();
            var cards = this.mainService.GetCards().ToList();

            for (int i = 0; i < registers.Count; i++)
            {
                registers[i].Content = cards[i];
            }

            registers[2].Content = cards[1];

            this.mainService.SetupRegisters(registers);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void SetupRegisters_NotAllRegistersAreFilled_Error()
        {
            this.SetupGame();
            var registers = this.mainService.GetCurrentGameInfo().Registers.ToList();
            var cards = this.mainService.GetCards().ToList();

            for (int i = 0; i < registers.Count; i++)
            {
                registers[i].Content = cards[i];
            }

            registers[2].Content = null;

            this.mainService.SetupRegisters(registers);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void SetupRegisters_SomeRegisterWithFakeCard_Error()
        {
            this.SetupGame();
            var registers = this.mainService.GetCurrentGameInfo().Registers.ToList();
            var cards = this.mainService.GetCards().ToList();

            for (int i = 0; i < registers.Count; i++)
            {
                registers[i].Content = cards[i];
            }

            registers[3].Content = new TestCard()
                                       {
                                           Energy = 900,
                                           ID = "23",
                                           Speed = 1,
                                           Type = MoveDirectionEnum.MoveForward
                                       };

            this.mainService.SetupRegisters(registers);
        }

        [TestMethod]
        public void SetupRegisters_MakeMove()
        {
            this.SetupGame();
            var cards = this.mainService.GetCards().ToList();
            var registers = this.mainService.GetCurrentGameInfo().Registers.ToList();

            for (int i = 0; i < registers.Count; i++)
            {
                registers[i].Content = cards[i];
            }

        }

        #endregion

        private void SetupGame()
        {
            this.mainService.Login("1", "1");
            this.mainService.CreateRobot(1, "TestRobot");
            this.mainService.Play(1, 1, 0);
        }
    }
}
