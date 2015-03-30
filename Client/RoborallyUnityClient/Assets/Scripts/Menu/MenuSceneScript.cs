using UnityEngine;
using System.Collections;

public class MenuSceneScript : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCreateNewRobot()
    {
        Application.LoadLevelAsync("CreateNewRobot");
    }

    public void OnStartGame()
    {
        Application.LoadLevelAsync("Main");
    }
}
