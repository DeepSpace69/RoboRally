using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CreateRobotMain : MonoBehaviour
{
    public static GameObject SelectedRobot;

    public InputField RobotNameTextBox;

    // Use this for initialization
    void Start()
    {

    }

    void Awake()
    {
       // Instantiate(RobotModel1);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CreateRobot()
    {
        PhotonServer.Instance.CreateRobotCompleted += OnCreateRobotCompleted;
        PhotonServer.Instance.CreateRobot(this.RobotNameTextBox.text, SelectedRobot.tag);
    }

    void OnCreateRobotCompleted()
    {
        PhotonServer.Instance.CreateRobotCompleted -= OnCreateRobotCompleted;
        GoHome();
    }

    public void GoHome()
    {
        Application.LoadLevelAsync("MenuScene");
    }
}
