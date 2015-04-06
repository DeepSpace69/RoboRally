using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

using EmitMapper;

using Photon.SocketServer;

using Roborally.Communication.Data.DataContracts;
using Roborally.Communication.ServerInterfaces;

namespace Roborally.Server.Photon
{
    /// <summary>The main peer.</summary>
    public partial class MainPeer
    {
        private void CreateRobot(OperationRequest operationRequest, SendParameters sendParameters)
        {
            var incoming = new CreateRobotParameters(operationRequest.Parameters);
            this.mainService.CreateRobot(Convert.ToInt32(incoming.ModelId), incoming.Name);
            var response = new OperationResponse(operationRequest.OperationCode);
            this.SendOperationResponse(response, sendParameters);
        }

        private void Login(OperationRequest operationRequest, SendParameters sendParameters)
        {
            var incoming = new LoginParameters(operationRequest.Parameters);
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

            var response = new OperationResponse(operationRequest.OperationCode, photonUser.ToParameters());
            this.SendOperationResponse(response, sendParameters);
        }

        private void GetMyRobots(OperationRequest operationRequest, SendParameters sendParameters)
        {
            var myRobots = this.mainService.GetMyRobots();
            var mapper = ObjectMapperManager.DefaultInstance.GetMapper<IRobot, PhotonRobot>();

            List<PhotonRobot> listToSerialize = new List<PhotonRobot>();
            foreach (var myRobot in myRobots)
            {
                var photonRobot = mapper.Map(myRobot);
                listToSerialize.Add(photonRobot);
            }

            XmlSerializer serializer = new XmlSerializer(typeof(List<PhotonRobot>));

            string stringToSend;
            using (StringWriter stringWriter = new StringWriter())
            {
                serializer.Serialize(stringWriter, listToSerialize);

                stringToSend = stringWriter.ToString();
            }

            var response = new OperationResponse(operationRequest.OperationCode, new Dictionary<byte, object>() { { 1, stringToSend } });
            this.SendOperationResponse(response, sendParameters);
        }
    }
}
