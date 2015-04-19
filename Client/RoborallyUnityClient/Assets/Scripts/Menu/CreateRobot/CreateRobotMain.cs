using UnityEngine;
using System.Collections;

using Assets.Helpers;
using Assets.Scripts;

using Roborally.Communication.Data.DataContracts;

using UnityEngine.UI;

public class CreateRobotMain : MonoBehaviour
{
    public GameObject RobotsPanel;

    public InputField RobotNameTextBox;

    public ScreenManagerScript screenManagerScript;

    public Animator MainMenu;

    public void CreateRobot()
    {
        var selectedRobot = SelectionManager.GetSelectedChild(this.RobotsPanel);

        if (selectedRobot == null)
        {
            return;
        }

        PhotonServer.Instance.CreateRobotCompleted += this.OnCreateRobotCompleted;
        var modelId = GameObjectRepository.Get<PhotonRobotModel>(selectedRobot);

        PhotonServer.Instance.CreateRobot(this.RobotNameTextBox.text, modelId.Id);
    }    

    private void OnCreateRobotCompleted()
    {
        PhotonServer.Instance.CreateRobotCompleted -= this.OnCreateRobotCompleted;
        this.screenManagerScript.OpenPanel(this.MainMenu);
    }
}
