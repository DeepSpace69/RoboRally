using UnityEngine;
using System.Collections;

using Assets.Helpers;
using Assets.Scripts;

using Roborally.Communication.Data.DataContracts;

public class StartNewGameMainController : MonoBehaviour
{
    public GameObject MapsPanel;

    public GameObject RobotsPanel;

    public void StartGame()
    {
        var selectedRobot = SelectionManager.GetSelectedChild(this.RobotsPanel);
        if (selectedRobot == null)
        {
            return;
        }

        var selectedMap = SelectionManager.GetSelectedChild(this.MapsPanel);
        if (selectedMap == null)
        {
            return;
        }

        var selectedRobotId = GameObjectRepository.Get<PhotonRobot>(selectedRobot).Id;
        var selectedMapId = GameObjectRepository.Get<PhotonMap>(selectedMap).Id;

        PhotonServer.Instance.StartGameCompleted += this.OnStartGameCompleted;
        PhotonServer.Instance.StartGame(selectedRobotId, selectedMapId, 0);
    }

    private void OnStartGameCompleted()
    {
        Application.LoadLevel("GameScene");
    }
}
