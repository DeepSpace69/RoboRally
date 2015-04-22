using System;
using System.Collections.Generic;

using ExitGames.Client.Photon;

using Roborally.Communication.Data.DataContracts;
using Roborally.Communication.Data.Operations;

public partial class PhotonServer
{
    private readonly Dictionary<byte, Action<OperationResponse>> operationHandlersDictionary =
        new Dictionary<byte, Action<OperationResponse>>();

    /// <summary>The create robot completed.</summary>
    public event Action CreateRobotCompleted;

    /// <summary>The get my robots completed.</summary>
    public event Action<List<PhotonRobot>> GetMyRobotsCompleted;

    /// <summary>The get robot models completed.</summary>
    public event Action<List<PhotonRobotModel>> GetRobotModelsCompleted;

    /// <summary>The login completed.</summary>
    public event Action<bool> LoginCompleted;

    /// <summary>The get maps completed.</summary>
    public event Action<List<PhotonMap>> GetMapsCompleted;

    /// <summary>The start game completed.</summary>
    public event Action StartGameCompleted;

    /// <summary>The get current game info completed.</summary>
    public event Action<PhotonCurrentGameInfo> GetCurrentGameInfoCompleted;

    private void SetupOperationHandlers()
    {
        this.operationHandlersDictionary.Add(OperationCodes.CreateRobotOperationCode, this.OnCreateRobotCompleted);
        this.operationHandlersDictionary.Add(OperationCodes.GetMyRobotsOperationCode, this.OnGetMyRobotsCompleted);
        this.operationHandlersDictionary.Add(OperationCodes.GetRobotsModelsOperationCode, this.OnGetRobotModelsCompleted);
        this.operationHandlersDictionary.Add(OperationCodes.LoginOperationCode, this.OnLoginCompleted);
        this.operationHandlersDictionary.Add(OperationCodes.GetMapsOperationCode, this.OnGetMapsCompleted);
        this.operationHandlersDictionary.Add(OperationCodes.StartGameOperationCode, this.OnStartGameCompleted);
        this.operationHandlersDictionary.Add(OperationCodes.GetCurrentGameInfoOperationCode, this.OnGetCurrentGameInfo);
    }
}