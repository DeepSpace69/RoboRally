using System;
using System.Collections.Generic;

using ExitGames.Client.Photon;

using Roborally.Communication.Data;
using Roborally.Communication.Data.DataContracts;
using Roborally.Communication.Data.Operations;

/// <summary>The photon server.</summary>
public partial class PhotonServer
{
    public void GetCurrentGameInfo()
    {
        this.peer.OpCustom(OperationCodes.GetCurrentGameInfoOperationCode);
    }

    private void OnGetCurrentGameInfo(OperationResponse operationResponse)
    {
        var currentGameInfoString = operationResponse.Parameters[1].ToString();
        currentGameInfoString =
            currentGameInfoString.Replace(
                "http://schemas.microsoft.com/2003/10/Serialization/Arrays",
                "http://schemas.datacontract.org/2004/07/Roborally.Communication.ServerInterfaces");
        var currentGameInfo = currentGameInfoString.Deserialize<PhotonCurrentGameInfo>();
        if (this.GetCurrentGameInfoCompleted != null)
        {
            this.GetCurrentGameInfoCompleted(currentGameInfo);
        }
    }
}