using System.Collections.Generic;

using Roborally.Communication.Data;

using UnityEngine;
using Roborally.Communication.Data.DataContracts;
using Roborally.Communication.ServerInterfaces;

public class BoardBuilder : MonoBehaviour
{
    public GameObject plate;
    public GameObject wall;

    void OnGUI()
    {

        GUI.Label(new Rect(5, 30, 100, 20), PhotonServer.Instance.Status);
    }

    // Use this for initialization
    void Awake()
    {
        //PhotonCurrentGameInfo gameInfo = new PhotonCurrentGameInfo();
        //gameInfo.Board = new PhotonBoard() { BoardObjects = new List<IBoardObject>() { new PhotonEmptyCell() { Position = new PhotonPosition() { X = 1 } } } };
        //var serString = gameInfo.SerializeToXml();
        ////System.IO.File.WriteAllText("c:\\1.txt", serString);
        //var game = serString.Deserialize<PhotonCurrentGameInfo>();
        PhotonServer.Instance.Connect();
    }

    public void BuildScene()
    {
        PhotonServer.Instance.GetCurrentGameInfoCompleted += this.OnGetCurrentGameInfoCompleted;
        PhotonServer.Instance.GetCurrentGameInfo();
    }

    private void OnGetCurrentGameInfoCompleted(PhotonCurrentGameInfo gameInfo)
    {
        PhotonServer.Instance.GetCurrentGameInfoCompleted -= this.OnGetCurrentGameInfoCompleted;

        this.BuildMap(gameInfo);
    }

    private void BuildMap(PhotonCurrentGameInfo gameInfo)
    {
        foreach (var boardObject in gameInfo.Board.BoardObjects)
        {
            var cell = boardObject as PhotonEmptyCell;
            if (cell != null)
            {
                var cellPlate = Instantiate(plate);
                cellPlate.transform.position = new Vector3(cell.Position.X, cell.Position.Y, 0);
            }
        }
    }
}
