using System;
using System.Collections.Generic;
using System.Linq;

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
        }

        [OperationCodeAttribute(Code = OperationCodes.GetCurrentGameInfoOperationCode)]
        private OperationResponse GetCurrentGameInfo(OperationRequest operationRequest)
        {
            var gameInfo = this.mainService.GetCurrentGameInfo();
            //var mapper = ObjectMapperManager.DefaultInstance.GetMapper<ICurrentGameInfo, PhotonCurrentGameInfo>();
            //var result = mapper.Map(gameInfo);

            var response = new OperationResponse(operationRequest.OperationCode, gameInfo.ToXmlPhotonParameters());
            return response;
        }
    }
}
