using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon;

public class PhotonServer : IPhotonPeerListener
{
    PhotonPeer peer;
    private static PhotonServer instance;
    private bool isConnected;

    private PhotonServer()
    {
        this.peer = new PhotonPeer(this, ConnectionProtocol.Tcp);
        this.Connect();
        this.lastConnect = DateTime.Now;
        this.lastPeerService = DateTime.Now;
    }

    public void Connect()
    {
        Status = "Connecting...";
        this.peer.Connect("127.0.0.1:4530", "Roborally");

    }

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

    public string Status { get; set; }


    public void DebugReturn(DebugLevel level, string message)
    {

    }

    public void OnEvent(EventData eventData)
    {

    }

    public void OnOperationResponse(OperationResponse operationResponse)
    {
        this.Status = operationResponse.Parameters[(byte)102].ToString();
    }

    public void OnStatusChanged(StatusCode statusCode)
    {
        switch (statusCode)
        {
            case StatusCode.Connect:
                Status = "Connected";
                this.isConnected = true;
                break;
            case StatusCode.Disconnect:
            case StatusCode.DisconnectByServer:
            case StatusCode.DisconnectByServerLogic:
            case StatusCode.DisconnectByServerUserLimit:
            case StatusCode.TimeoutDisconnect:
                Status = "Disconnected";
                this.isConnected = false;
                break;
            default:
                Status = "Unknown";
                break;
        }
    }

    private DateTime lastConnect;
    private DateTime lastPeerService;

    public void Update(Action<string> Log)
    {
        if (!this.isConnected && DateTime.Now > this.lastConnect)
        {
            Log("Connect" + DateTime.Now);
            this.lastConnect = DateTime.Now.AddSeconds(10);
            this.Connect();
        }

        if (this.peer != null && DateTime.Now > lastPeerService)
        {
            Log("Ping" + DateTime.Now);
            lastPeerService = DateTime.Now.AddSeconds(3);
            this.peer.Service();
        }
    }

    IEnumerator Wait(float sec)
    {
        yield return new WaitForSeconds(sec);
    }


    public void Login(string login, string password)
    {
        this.peer.OpCustom(11, new Dictionary<byte, object> { { 101, login }, { 102, password } }, false);
    }

}