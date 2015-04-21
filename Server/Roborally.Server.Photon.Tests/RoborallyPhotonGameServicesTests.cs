using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Photon.SocketServer;

using Roborally.Communication.Data;
using Roborally.Communication.Data.DataContracts;
using Roborally.Communication.Data.Operations;
using Roborally.Communication.ServerInterfaces;
using Roborally.Server.Photon.Services;
using Roborally.Server.TestClass.Mocks;

namespace Roborally.Server.Photon.Tests
{
    [TestClass]
    public class RoborallyPhotonGameServicesTests
    {
        private IMainService mainService;
        private RoborallyPhotonServiceRepository repository;

        [TestInitialize]
        public void Init()
        {
            this.mainService = new MainServiceMock();
            this.repository = new RoborallyPhotonServiceRepository();
            var service = new RoborallyPhotonGameServices(this.repository, this.mainService);
        }       

        [TestMethod]
        public void GetCurrentGameInfo_MainServiceWasCalled()
        {            
            var currentGameInfo = this.mainService.GetCurrentGameInfo();

            var response = this.repository.Execute(new OperationRequest(OperationCodes.GetCurrentGameInfoOperationCode));
            var actualString = response.Parameters[1].ToString();
            var actual = actualString.Deserialize<PhotonCurrentGameInfo>();

            Assert.AreEqual(currentGameInfo.CurrentState, actual.CurrentState);
            Assert.AreEqual(currentGameInfo.GameRobots.Count(), actual.GameRobots.Count());
            Assert.AreEqual(currentGameInfo.Registers.Count(), actual.Registers.Count());
            Assert.AreEqual(currentGameInfo.Board.BoardObjects.Count(), actual.Board.BoardObjects.Count());
        }
    }
}
