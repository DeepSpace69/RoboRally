using System;
using System.Collections.Generic;

using ExitGames.Client.Photon;

using Roborally.Communication.Data.DataContracts;

/// <summary>The photon server.</summary>
public partial class PhotonServer
{
    public event Action<bool> LoginCompleted;

    public event Action CreateRobotCompleted;

    /// <summary>The login operation.</summary>
    /// <param name="login">The login.</param>
    /// <param name="password">The password.</param>
    public void Login(string login, string password)
    {
        var loginParams = new LoginParameters() { Login = login, Password = password };
        this.peer.OpCustom(LoginParameters.OperationCode, loginParams.ToParameters(), false);
    }

    private void OnLoginCompleted(OperationResponse operationResponse)
    {
        var user = new PhotonUser(operationResponse.Parameters);
        if (user.ID != "0")
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

    public void CreateRobot(string robotName, string modelId)
    {
        var createRobotParams = new CreateRobotParameters() { ModelId = modelId, Name = robotName };
        this.peer.OpCustom(CreateRobotParameters.OperationCode, createRobotParams.ToParameters(), false);
    }

    private void OnCreateRobotCompleted(OperationResponse operationResponse)
    {
        if (this.CreateRobotCompleted != null)
        {
            this.CreateRobotCompleted();
        }
    }
}