using System;
using System.Collections.Generic;

using AutoMapper;

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
    public class MapperTests
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
        public void TestNestedMappings()
        {
            Mapper.CreateMap<GameRobot, PhotonGameRobot>();
            Mapper.CreateMap<CurrentGameInfo, PhotonCurrentGameInfo>()
                  .ForMember(
                      dest => dest.GameRobots,
                      opt => opt.MapFrom(q => Mapper.Map<IEnumerable<IGameRobot>, IEnumerable<PhotonGameRobot>>(q.GameRobots)));

            Mapper.AssertConfigurationIsValid();
            var gameInfo = this.CreateCurrentGameInfo();
            var res = Mapper.Map<CurrentGameInfo, PhotonCurrentGameInfo>(gameInfo);
            var a = 1;
        }

        private CurrentGameInfo CreateCurrentGameInfo()
        {
            var gameInfo = new CurrentGameInfo();
            gameInfo.GameRobots = this.CreateRobots();
            return gameInfo;
        }

        private IEnumerable<IGameRobot> CreateRobots()
        {
            var result = new List<GameRobot>()
                             {
                                 new GameRobot()
                                     {
                                         CurrentDirection = DirectionEnum.Down,
                                         HealthPoint = 11,
                                         IsPowerDown = false,
                                         LifeAmount = 2,
                                         Name = "Terminator",
                                         Position = new Position() { X = 0, Y = 0 },
                                         RobotId = 1,
                                         RobotsModel = new PhotonRobotModel() { Id = 1, Name = "Tank" }
                                     },
                                     new GameRobot()
                                     {
                                         CurrentDirection = DirectionEnum.Down,
                                         HealthPoint = 11,
                                         IsPowerDown = false,
                                         LifeAmount = 2,
                                         Name = "Terminator2",
                                         Position = new Position() { X = 1, Y = 1 },
                                         RobotId = 2,
                                         RobotsModel = new PhotonRobotModel() { Id = 1, Name = "Tank2" }
                                     },
                             };
            return result;
        }
    }
}
