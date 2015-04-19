using System.Collections.Generic;
using System.Linq;

using Assets.Scripts.Menu;

using Roborally.Communication.Data.DataContracts;

using UnityEngine;
using UnityEngine.UI;

public class LoadMyRobotsScript : BaseObjectLoader
{
    public override void LoadObjects()
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
            var uiRobot = this.CreateGameObject(robot);
            var textComponent = uiRobot.GetComponentsInChildren<Text>().First();
            textComponent.text = robot.Name;

            var modelPrefab = Resources.Load<GameObject>("RobotModels/RobotModel" + robot.ModelId);
            var model = Instantiate(modelPrefab);
            var container = uiRobot.transform.GetChild(0);
            model.transform.SetParent(container);
            model.transform.localPosition = new Vector3(0, 0, 0);
        }
    }
}
