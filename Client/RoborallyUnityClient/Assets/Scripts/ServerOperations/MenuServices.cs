using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

using ExitGames.Client.Photon;

using Roborally.Communication.Data;
using Roborally.Communication.Data.DataContracts;
using Roborally.Communication.Data.Operations;

/// <summary>The photon server.</summary>
public partial class PhotonServer
{
    /// <summary>The login operation.</summary>
    /// <param name="login">The login.</param>
    /// <param name="password">The password.</param>
    public void Login(string login, string password)
    {
        var loginParams = new LoginParameters() { Login = login, Password = password };
        this.peer.OpCustom(OperationCodes.LoginOperationCode, loginParams.ToDictionary());
    }

    private void OnLoginCompleted(OperationResponse operationResponse)
    {
        var user = operationResponse.Parameters.Deserialize<PhotonUser>();
        if (user.ID != 0)
        {
            this.Status = user.Name;
            if (this.LoginCompleted != null)
            {
                this.LoginCompleted(true);
            }
        }
        else
        {
            this.Status = "Denied";
        }
    }

    public void CreateRobot(string robotName, int modelId)
    {
        var createRobotParams = new CreateRobotParameters() { ModelId = modelId, Name = robotName };
        this.peer.OpCustom(OperationCodes.CreateRobotOperationCode, createRobotParams.ToDictionary());
    }

    private void OnCreateRobotCompleted(OperationResponse operationResponse)
    {
        if (this.CreateRobotCompleted != null)
        {
            this.CreateRobotCompleted();
        }
    }

    public void GetMyRobots()
    {
        this.peer.OpCustom(OperationCodes.GetMyRobotsOperationCode);
    }

    private void OnGetMyRobotsCompleted(OperationResponse operationResponse)
    {
        if (this.GetMyRobotsCompleted != null)
        {
            var robots = operationResponse.Parameters[1].ToString().Deserialize<List<PhotonRobot>>();
            this.GetMyRobotsCompleted(robots);
        }
    }

    public void GetRobotModels()
    {
        this.peer.OpCustom(OperationCodes.GetRobotsModelsOperationCode);
    }

    private void OnGetRobotModelsCompleted(OperationResponse operationResponse)
    {
        if (this.GetRobotModelsCompleted != null)
        {
            var robotModels = operationResponse.Parameters[1].ToString().Deserialize<List<PhotonRobotModel>>();
            this.GetRobotModelsCompleted(robotModels);
        }
    }
}