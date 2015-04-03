using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Roborally.Server.Tests
{
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
            Assert.IsTrue(models.Count > 0);
            Assert.IsTrue(models.Any(p => p.Id == 1));
        }

        [TestMethod]
        public void CreateRobot_TestWithFirstModel_RobotCreated()
        {
            this.SetupGame();

            var myRobots = this.mainService.GetMyRobots();

            Assert.AreEqual(2, myRobots.Count);
            Assert.AreEqual(myRobots.First().Name, "TestRobot");
            Assert.AreEqual(myRobots.First().ModelId, 1);
        }

        [TestMethod]
        public void GetMaps_AnyMapsExist()
        {
            var mapsCollection = this.mainService.GetMaps();

            Assert.IsTrue(mapsCollection.Count > 0);
            Assert.IsTrue(mapsCollection.Any(p => p.Id == 1));
        }

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
            this.mainService.Play(1, 1, 0);

            var gameInfo = this.mainService.GetCurrentGameInfo();

            // Other
            Assert.AreEqual(GameStateEnum.DrawCards, gameInfo.CurrentState);
            Assert.IsNotNull(gameInfo);
            Assert.AreEqual(5, gameInfo.Registers.Count);

            // Registers
            CollectionAssert.AllItemsAreUnique(gameInfo.Registers.Select(p => p.ID).ToList());
            Assert.IsTrue(gameInfo.Registers.All(p => p.IsAvailable));
            Assert.IsTrue(gameInfo.Registers.All(p => p.Content == null));

            // Robots
            Assert.AreEqual(1, gameInfo.GameRobots.Count);
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
        public void GetCards_AllCards()
        {
            this.SetupGame();
            this.mainService.Play(1, 1, 0);
            var cards = this.mainService.GetCards();

            Assert.AreEqual(9, cards.Count);
            Assert.IsTrue(cards.All(p => p.Energy > 0 && p.Energy < 1000));
        }

        [TestMethod]
        public void SetRegister()
        {
            this.SetupGame();
            this.mainService.Play(1, 1, 0);
            var cards = this.mainService.GetCards();

            var register = new TestRegister();
        }

        [TestMethod]
        public void SetupRegisters_MakeMove()
        {
            this.SetupGame();
            this.mainService.Play(1, 1, 0);
            var cards = this.mainService.GetCards();
            var registers = this.mainService.GetCurrentGameInfo().Registers;
            var moveForvardCard = cards.FirstOrDefault(p => p.Type == MoveDirectionEnum.MoveForward);

            if (moveForvardCard != null)
            {
                Assert.IsTrue(moveForvardCard.Speed > 0 && moveForvardCard.Speed < 3);
                this.mainService.SetupRegisters(
                    new[] { new TestRegister() { Content = moveForvardCard, ID = registers.First().ID } });

                var newRobotPosition = this.mainService.GetCurrentGameInfo().GameRobots.FirstOrDefault().Position;
                
                //robot moves forward from (1,2) to (1,1) or (1,0) regarding to speed
                Assert.AreEqual(2 - moveForvardCard.Speed, newRobotPosition.Y);
            }
        }




        private void SetupGame()
        {
            this.mainService.Login("1", "1");
            this.mainService.CreateRobot(1, "TestRobot");
        }
    }
}
