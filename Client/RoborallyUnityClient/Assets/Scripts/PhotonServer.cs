using System;
using System.Collections.Generic;

using ExitGames.Client.Photon;
using Roborally.Communication.Data.DataContracts;

/// <summary>The photon server.</summary>
public partial class PhotonServer : IPhotonPeerListener
{
    /// <summary>The instance.</summary>
    private static PhotonServer instance;

    /// <summary>The is connected.</summary>
    private bool isConnected;

    /// <summary>The last connect.</summary>
    private DateTime lastConnect;

    /// <summary>The last peer service.</summary>
    private DateTime lastPeerService;

    /// <summary>The peer.</summary>
    private PhotonPeer peer;

    /// <summary>Prevents a default instance of the <see cref="PhotonServer"/> class from being created.</summary>
    private PhotonServer()
    {
        this.peer = new PhotonPeer(this, ConnectionProtocol.Tcp);
        this.Connect();
        this.lastConnect = DateTime.Now;
        this.lastPeerService = DateTime.Now;
    }

    /// <summary>Gets the instance.</summary>
    public static PhotonServer Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new PhotonServer();
            }

            return instance;
        }
    }

    /// <summary>Gets or sets the status.</summary>
    public string Status { get; set; }

    /// <summary>The debug return.</summary>
    /// <param name="level">The level.</param>
    /// <param name="message">The message.</param>
    public void DebugReturn(DebugLevel level, string message)
    {
    }

    /// <summary>The on event.</summary>
    /// <param name="eventData">The event data.</param>
    public void OnEvent(EventData eventData)
    {
    }

    /// <summary>The on operation response.</summary>
    /// <param name="operationResponse">The operation response.</param>
    public void OnOperationResponse(OperationResponse operationResponse)
    {
        switch (operationResponse.OperationCode)
        {
            case LoginParameters.OperationCode:
                this.OnLoginCompleted(operationResponse);
                break;
        }        
    }

    /// <summary>The on status changed.</summary>
    /// <param name="statusCode">The status code.</param>
    public void OnStatusChanged(StatusCode statusCode)
    {
        switch (statusCode)
        {
            case StatusCode.Connect:
                this.Status = "Connected";
                this.isConnected = true;
                break;
            case StatusCode.Disconnect:
            case StatusCode.DisconnectByServer:
            case StatusCode.DisconnectByServerLogic:
            case StatusCode.DisconnectByServerUserLimit:
            case StatusCode.TimeoutDisconnect:
                this.Status = "Disconnected";
                this.isConnected = false;
                break;
            default:
                this.Status = "Unknown";
                break;
        }
    }

    /// <summary>The connect.</summary>
    public void Connect()
    {
        this.Status = "Connecting...";
        this.peer.Connect("127.0.0.1:4530", "Roborally");
    }

    /// <summary>The update.</summary>
    public void Update()
    {
        if (!this.isConnected && DateTime.Now > this.lastConnect)
        {
            this.lastConnect = DateTime.Now.AddSeconds(10);
            this.Connect();
        }

        if (this.peer != null && DateTime.Now > this.lastPeerService)
        {
            this.lastPeerService = DateTime.Now.AddSeconds(1);
            this.peer.Service();
        }
    }    
}