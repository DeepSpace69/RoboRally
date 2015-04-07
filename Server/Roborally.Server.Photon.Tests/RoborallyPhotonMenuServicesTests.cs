using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Photon.SocketServer;

using Roborally.Communication.Data.DataContracts;
using Roborally.Communication.Data.Operations;
using Roborally.Communication.ServerInterfaces;
using Roborally.Server.Photon.Interfaces;
using Roborally.Server.Photon.Services;

using Telerik.JustMock;

namespace Roborally.Server.Photon.Tests
{
    [TestClass]
    public class RoborallyPhotonMenuServicesTests
    {
        private IMainService mainService;

        private IServiceRepository repository;

        [TestInitialize]
        public void Init()
        {
            this.mainService = Mock.Create<IMainService>();
            this.repository = new RoborallyPhotonServiceRepository();
            var service = new RoborallyPhotonMenuServices(this.repository, this.mainService);
        }

        [TestMethod]
        public void Login_RegularParameters_MainServiceWasCalled()
        {
            var parameters = new LoginParameters() { Login = "1", Password = "1" };
            var request = new OperationRequest(OperationCodes.LoginOperationCode, parameters.ToParameters());
            this.repository.Execute(request);

            Mock.Assert(() => this.mainService.Login(
                Arg.Matches<string>(login => login == "1"),
                Arg.Matches<string>(pass => pass == "1")));
        }

        [TestMethod]
        public void GetMaos_RegularParameters_MainServiceWasCalled()
        {
            var request = new OperationRequest(OperationCodes.GetMapsOperationCode);
            this.repository.Execute(request);
            Mock.Assert(() => this.mainService.GetMaps());
        }
    }
}
