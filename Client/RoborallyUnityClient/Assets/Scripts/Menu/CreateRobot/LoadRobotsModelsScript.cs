using UnityEngine;
using System.Collections;

using Roborally.Communication.Data.DataContracts;
using System.Collections.Generic;
using System.Linq;

using Assets.Scripts;

using UnityEngine.UI;

public class LoadRobotsModelsScript : MonoBehaviour
{
    public GameObject RobotModelSelector;
    public BaseScreenController baseScreenController;

    void Awake()
    {
        this.baseScreenController.OnScreenShowed += this.OnScreenShowed;
        this.baseScreenController.OnScreenHidden += this.OnScreenHidden;
    }

    private void OnScreenHidden()
    {
        this.CleanPanel();
    }

    private void OnScreenShowed()
    {
        this.CleanPanel();
        this.LoadMyRobots();
    }

    private void CleanPanel()
    {
        for (int i = this.gameObject.transform.childCount - 1; i >= 0; i--)
        {
            var robot = this.gameObject.transform.GetChild(i).gameObject;
            Destroy(robot);
        }
    }

    public void LoadMyRobots()
    {
        PhotonServer.Instance.GetRobotModelsCompleted += this.OnGetRobotModelsCompleted;
        PhotonServer.Instance.GetRobotModels();
    }

    private void OnGetRobotModelsCompleted(List<PhotonRobotModel> robots)
    {
        PhotonServer.Instance.GetRobotModelsCompleted -= this.OnGetRobotModelsCompleted;
        this.ShowRobots(robots);
    }

    private void ShowRobots(List<PhotonRobotModel> robotModels)
    {
        foreach (var robotModel in robotModels)
        {
            var uiRobot = Instantiate(this.RobotModelSelector);
            GameObjectRepository.Register(uiRobot, robotModel);
            var textComponent = uiRobot.GetComponentsInChildren<Text>().First();
            textComponent.text = robotModel.Name;

            uiRobot.transform.SetParent(this.gameObject.transform);
            uiRobot.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
