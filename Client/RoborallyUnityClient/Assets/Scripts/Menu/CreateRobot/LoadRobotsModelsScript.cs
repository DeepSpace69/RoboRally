using UnityEngine;
using System.Collections;

using Roborally.Communication.Data.DataContracts;
using System.Collections.Generic;
using System.Linq;

using Assets.Scripts;
using Assets.Scripts.Menu;

using UnityEngine.UI;

public class LoadRobotsModelsScript : BaseObjectLoader
{
    public override void LoadObjects()
    {
        PhotonServer.Instance.GetRobotModelsCompleted += this.OnGetRobotModelsCompleted;
        PhotonServer.Instance.GetRobotModels();
    }

    private void OnGetRobotModelsCompleted(List<PhotonRobotModel> robotModels)
    {
        PhotonServer.Instance.GetRobotModelsCompleted -= this.OnGetRobotModelsCompleted;
        this.ShowRobotModels(robotModels);
    }

    private void ShowRobotModels(List<PhotonRobotModel> robotModels)
    {
        foreach (var robotModel in robotModels)
        {
            var uiRobot = this.CreateGameObject(robotModel);
            
            var textComponent = uiRobot.GetComponentsInChildren<Text>().First();
            textComponent.text = robotModel.Name;
            var modelPrefab = Resources.Load<GameObject>("RobotModels/RobotModel" + robotModel.Id);
            var model = Instantiate(modelPrefab);
            var container = uiRobot.transform.GetChild(0);
            model.transform.SetParent(container);
            model.transform.localPosition = new Vector3(0, 0, 0);
        }
    }
}
