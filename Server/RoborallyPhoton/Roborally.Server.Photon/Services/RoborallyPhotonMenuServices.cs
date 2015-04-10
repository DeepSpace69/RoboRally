using System;
using System.Linq;

using EmitMapper;

using Photon.SocketServer;

using Roborally.Communication.Data;
using Roborally.Communication.Data.DataContracts;
using Roborally.Communication.Data.Operations;
using Roborally.Communication.ServerInterfaces;
using Roborally.Server.Photon.Interfaces;

namespace Roborally.Server.Photon.Services
{
    /// <summary>The roborally photon menu services.</summary>
    public class RoborallyPhotonMenuServices : RoborallyPhotonServicesBase
    {
        private readonly IMainService mainService;

        /// <summary>Initializes a new instance of the <see cref="RoborallyPhotonMenuServices"/> class.</summary>
        /// <param name="repository">The repository.</param>
        /// <param name="mainService">The main service.</param>
        public RoborallyPhotonMenuServices(IServiceRepository repository, IMainService mainService)
            : base(repository)
        {
            this.mainService = mainService;
        }

        [OperationCodeAttribute(Code = OperationCodes.CreateRobotOperationCode)]
        private OperationResponse CreateRobot(OperationRequest operationRequest)
        {
            var incoming = operationRequest.Parameters.Deserialize<CreateRobotParameters>();
            this.mainService.CreateRobot(Convert.ToInt32(incoming.ModelId), incoming.Name);
            var response = new OperationResponse(operationRequest.OperationCode);
            return response;
        }

        [OperationCodeAttribute(Code = OperationCodes.LoginOperationCode)]
        private OperationResponse Login(OperationRequest operationRequest)
        {
            var incoming = operationRequest.Parameters.Deserialize<LoginParameters>();
            var user = this.mainService.Login(incoming.Login, incoming.Password);

            PhotonUser photonUser;
            if (user != null)
            {
                photonUser = ObjectMapperManager.DefaultInstance.GetMapper<IUser, PhotonUser>().Map(user);
            }
            else
            {
                photonUser = new PhotonUser() { ID = 0, Name = string.Empty };
            }

            var response = new OperationResponse(operationRequest.OperationCode, photonUser.ToDictionary());
            return response;
        }

        [OperationCodeAttribute(Code = OperationCodes.GetMyRobotsOperationCode)]
        private OperationResponse GetMyRobots(OperationRequest operationRequest)
        {
            var myRobots = this.mainService.GetMyRobots();
            var mapper = ObjectMapperManager.DefaultInstance.GetMapper<IRobot, PhotonRobot>();
            var listToSerialize = myRobots.Select(mapper.Map).ToList();
            var response = new OperationResponse(operationRequest.OperationCode, listToSerialize.ToXmlPhotonParameters());
            return response;
        }

        [OperationCodeAttribute(Code = OperationCodes.GetMapsOperationCode)]
        private OperationResponse GetMaps(OperationRequest operationRequest)
        {
            var maps = this.mainService.GetMaps();
            var mapper = ObjectMapperManager.DefaultInstance.GetMapper<IMap, PhotonMap>();
            var listToSerialize = maps.Select(mapper.Map).ToList();
            var response = new OperationResponse(operationRequest.OperationCode, listToSerialize.ToXmlPhotonParameters());
            return response;
        }

        [OperationCodeAttribute(Code = OperationCodes.GetRobotsModelsOperationCode)]
        private OperationResponse GetRobotsModels(OperationRequest operationRequest)
        {
            var models = this.mainService.GetRobotsModels();
            var mapper = ObjectMapperManager.DefaultInstance.GetMapper<IRobotsModel, PhotonRobotModel>();
            var listToSerialize = models.Select(mapper.Map).ToList();
            var response = new OperationResponse(operationRequest.OperationCode, listToSerialize.ToXmlPhotonParameters());
            return response;
        }

        [OperationCodeAttribute(Code = OperationCodes.StartGameOperationCode)]
        private OperationResponse StartGame(OperationRequest operationRequest)
        {
            var incoming = operationRequest.Parameters.Deserialize<StartGameParameters>();
            this.mainService.Play(incoming.RobotId, incoming.MapId, incoming.NumberOfPlayers);
            var response = new OperationResponse(operationRequest.OperationCode);
            return response;
        }
    }
}
