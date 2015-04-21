using System;
using System.Collections.Generic;
using System.Linq;

using AutoMapper;

using EmitMapper;

using Photon.SocketServer;

using Roborally.Communication.Data;
using Roborally.Communication.Data.DataContracts;
using Roborally.Communication.Data.DataContracts.BoardObjects;
using Roborally.Communication.Data.Operations;
using Roborally.Communication.ServerInterfaces;
using Roborally.Server.Photon.Interfaces;

namespace Roborally.Server.Photon.Services
{
    /// <summary>The roborally photon menu services.</summary>
    public class RoborallyPhotonGameServices : RoborallyPhotonServicesBase
    {
        private readonly IMainService mainService;

        /// <summary>Initializes a new instance of the <see cref="RoborallyPhotonGameServices"/> class.</summary>
        /// <param name="repository">The repository.</param>
        /// <param name="mainService">The main service.</param>
        public RoborallyPhotonGameServices(IServiceRepository repository, IMainService mainService)
            : base(repository)
        {
            this.mainService = mainService;
            this.ConfigureMappings();
        }

        private void ConfigureMappings()
        {
            Mapper.CreateMap<IBoard, PhotonBoard>();
            Mapper.CreateMap<IBoard, IBoard>().As<PhotonBoard>();

            Mapper.CreateMap<IMap, PhotonMap>();
            Mapper.CreateMap<IMap, IMap>().As<PhotonMap>();

            Mapper.CreateMap<IOrderCard, PhotonOrderCard>();
            Mapper.CreateMap<IOrderCard, IOrderCard>().As<PhotonOrderCard>();

            Mapper.CreateMap<IPosition, PhotonPosition>();
            Mapper.CreateMap<IPosition, IPosition>().As<PhotonPosition>();

            Mapper.CreateMap<IRegister, PhotonRegister>();
            Mapper.CreateMap<IRegister, IRegister>().As<PhotonRegister>();

            Mapper.CreateMap<IRobot, PhotonRobot>();
            Mapper.CreateMap<IRobot, IRobot>().As<PhotonRobot>();

            Mapper.CreateMap<IRobotsModel, PhotonRobotModel>();
            Mapper.CreateMap<IRobotsModel, IRobotsModel>().As<PhotonRobotModel>();

            Mapper.CreateMap<IGameRobot, PhotonGameRobot>();
            Mapper.CreateMap<IGameRobot, IGameRobot>().As<PhotonGameRobot>();

            Mapper.CreateMap<IGameRobot, PhotonGameRobot>();

            Mapper.CreateMap<IEmptyCell, PhotonEmptyCell>();

            Mapper.CreateMap<IBoardObject, IBoardObject>()
                  .ConvertUsing<BoardObjectConverter>();

            Mapper.CreateMap<ICurrentGameInfo, PhotonCurrentGameInfo>();
            Mapper.AssertConfigurationIsValid();
        }

        public class BoardObjectConverter : TypeConverter<IBoardObject, IBoardObject>
        {
            protected override IBoardObject ConvertCore(IBoardObject source)
            {
                if (source is IEmptyCell) return Mapper.Map<PhotonEmptyCell>(source);
                if (source is IGameRobot) return Mapper.Map<PhotonGameRobot>(source);
                return null;
            }
        }

        [OperationCodeAttribute(Code = OperationCodes.GetCurrentGameInfoOperationCode)]
        private OperationResponse GetCurrentGameInfo(OperationRequest operationRequest)
        {
            var gameInfo = this.mainService.GetCurrentGameInfo();
            var photonCurrentGameInfo = Mapper.Map<PhotonCurrentGameInfo>(gameInfo);
            var response = new OperationResponse(operationRequest.OperationCode, photonCurrentGameInfo.ToXmlPhotonParameters());
            return response;
        }
    }
}
