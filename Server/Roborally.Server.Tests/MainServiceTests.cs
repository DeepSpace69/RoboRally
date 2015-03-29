using System;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Roborally.Server.Tests
{
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
            var user = mainService.Login("1", "1");

            Assert.AreEqual("1", user.ID);
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
            mainService.Login("1", "1");

            mainService.CreateRobot(1, "TestRobot");

            var myRobots = mainService.GetMyRobots();

            Assert.AreEqual(1, myRobots.Count);
            Assert.AreEqual(myRobots.First().Name, "TestRobot");
            Assert.AreEqual(myRobots.First().ModelId, 1);
        }
    }
}
