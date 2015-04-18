using UnityEngine;
using System.Collections;

public class StartNewGameMainController : MonoBehaviour
{
    public LoadMyRobotsScript loadScript;

    // Use this for initialization
    void Awake()
    {
    }

    private void OnScreenShowed()
    {
        this.loadScript.LoadMyRobots();
    }

    public void OnMapClick()
    {
        Debug.Log("OK");
    }
}
