using System;
using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Photon.SocketServer;

using Roborally.Communication.Data;
using Roborally.Communication.Data.DataContracts;
using Roborally.Communication.Data.DataContracts.BoardObjects;
using Roborally.Communication.Data.Operations;
using Roborally.Communication.ServerInterfaces;
using Roborally.Server.BoardObjects;
using Roborally.Server.Photon.Interfaces;
using Roborally.Server.Photon.Services;

using Telerik.JustMock;

namespace Roborally.Server.Photon.Tests
{
    [TestClass]
    public class RoborallyPhotonGameServicesTests
    {
        private IMainService mainService;

        private IServiceRepository repository;

        [TestInitialize]
        public void Init()
        {
            this.mainService = Mock.Create<IMainService>();
            this.repository = new RoborallyPhotonServiceRepository();
            var service = new RoborallyPhotonGameServices(this.repository, this.mainService);
        }

        [TestMethod]
        public void GetCurrentGameInfo_MainServiceWasCalled()
        {
            var gameInfo = this.CreateCurrentGameInfo();

            Mock.Arrange(() => this.mainService.GetCurrentGameInfo()).Returns(gameInfo);
            var request = new OperationRequest(OperationCodes.GetCurrentGameInfoOperationCode);
            var response = this.repository.Execute(request);

            Mock.Assert(() => this.mainService.GetCurrentGameInfo());
        }

        private PhotonCurrentGameInfo CreateCurrentGameInfo()
        {
            var gameInfo = new PhotonCurrentGameInfo();
            gameInfo.Board = this.CreateBoard();
            gameInfo.CurrentState = GameStateEnum.DrawCards;
            gameInfo.GameRobots = this.CreateRobots();
            gameInfo.Registers = this.CreateRegisters();

            return gameInfo;
        }

        private IEnumerable<IRegister> CreateRegisters()
        {
            var registers = new List<Register>()
                                {
                                    new Register()
                                        {
                                            Content =
                                                new PhotonOrderCard()
                                                    {
                                                        Energy = 11,
                                                        ID = "1",
                                                        Speed = 1,
                                                        Type = MoveDirectionEnum.TurnLeft
                                                    },
                                            ID = "123",
                                            IsAvailable = true
                                        },
                                        new Register()
                                        {
                                            Content =
                                                new PhotonOrderCard()
                                                    {
                                                        Energy = 11,
                                                        ID = "1",
                                                        Speed = 1,
                                                        Type = MoveDirectionEnum.TurnLeft
                                                    },
                                            ID = "456",
                                            IsAvailable = true
                                        }
                                };



            return registers;
        }

        private IEnumerable<IGameRobot> CreateRobots()
        {
            var result = new List<PhotonGameRobot>()
                             {
                                 new PhotonGameRobot()
                                     {
                                         CurrentDirection = DirectionEnum.Down,
                                         HealthPoint = 11,
                                         IsPowerDown = false,
                                         LifeAmount = 2,
                                         Name = "Terminator",
                                         Position = new PhotonPosition() { X = 0, Y = 0 },
                                         RobotId = 1,
                                         RobotsModel = new PhotonRobotModel() { Id = 1, Name = "Tank" }
                                     },
                                     new PhotonGameRobot()
                                     {
                                         CurrentDirection = DirectionEnum.Down,
                                         HealthPoint = 11,
                                         IsPowerDown = false,
                                         LifeAmount = 2,
                                         Name = "Terminator2",
                                         Position = new PhotonPosition() { X = 1, Y = 1 },
                                         RobotId = 2,
                                         RobotsModel = new PhotonRobotModel() { Id = 1, Name = "Tank2" }
                                     },
                             };
            return result;
        }

        private IBoard CreateBoard()
        {
            var board = new PhotonBoard();
            board.BoardObjects = new List<PhotonEmptyCell>()
                                     {
                                         new PhotonEmptyCell() { Position = new PhotonPosition() { X = 0, Y = 0 } },
                                         new PhotonEmptyCell() { Position = new PhotonPosition() { X = 1, Y = 0 } },
                                         new PhotonEmptyCell() { Position = new PhotonPosition() { X = 2, Y = 0 } }
                                     };
            board.Map = new PhotonMap() { Id = 1, Name = "Hell" };
            return board;
        }
    }
}
