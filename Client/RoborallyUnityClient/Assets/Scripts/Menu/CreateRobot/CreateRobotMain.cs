using UnityEngine;
using System.Collections;

using Assets.Scripts;

using Roborally.Communication.Data.DataContracts;

using UnityEngine.UI;

public class CreateRobotMain : MonoBehaviour
{
    private GameObject selectedRobot;

    public InputField RobotNameTextBox;

    public ScreenManagerScript screenManagerScript;

    public Animator MainMenu;

    public HighlightRobotsModel highlightRobotsModel;

    public void CreateRobot()
    {
        PhotonServer.Instance.CreateRobotCompleted += this.OnCreateRobotCompleted;
        var modelId = GameObjectRepository.Get<PhotonRobotModel>(this.selectedRobot);

        PhotonServer.Instance.CreateRobot(this.RobotNameTextBox.text, modelId.Id);
    }

    public void SelectRobot(GameObject selectedRobot)
    {
        this.selectedRobot = selectedRobot;
        highlightRobotsModel.SetSelected(selectedRobot);
    }

    private void OnCreateRobotCompleted()
    {
        PhotonServer.Instance.CreateRobotCompleted -= this.OnCreateRobotCompleted;
        this.screenManagerScript.OpenPanel(this.MainMenu);
    }
}
