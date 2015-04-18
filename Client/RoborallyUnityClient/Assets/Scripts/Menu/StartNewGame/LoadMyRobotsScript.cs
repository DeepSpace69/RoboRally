using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Roborally.Communication.Data.DataContracts;

using UnityEngine.UI;

public class LoadMyRobotsScript : MonoBehaviour
{
    public GameObject RobotSelector;
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
        PhotonServer.Instance.GetMyRobotsCompleted += this.OnGetMyRobotsCompleted;
        PhotonServer.Instance.GetMyRobots();
    }

    private void OnGetMyRobotsCompleted(List<PhotonRobot> robots)
    {
        PhotonServer.Instance.GetMyRobotsCompleted -= this.OnGetMyRobotsCompleted;
        this.ShowRobots(robots);
    }

    private void ShowRobots(List<PhotonRobot> robots)
    {
        foreach (var robot in robots)
        {
            var uiRobot = Instantiate(this.RobotSelector);
            var textComponent = uiRobot.GetComponentsInChildren<Text>().First();
            textComponent.text = robot.Name;
            uiRobot.transform.SetParent(this.gameObject.transform);
            uiRobot.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
