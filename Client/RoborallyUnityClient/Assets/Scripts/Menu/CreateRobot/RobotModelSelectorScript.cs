using UnityEngine;
using System.Collections;

public class RobotModelSelectorScript : MonoBehaviour
{
    private CreateRobotMain mainScript;
    public void OnModelSelected()
    {
        if (this.mainScript == null)
        {
            this.mainScript = this.gameObject.GetComponentInParent<CreateRobotMain>();
        }
        this.mainScript.SelectRobot(this.gameObject);
    }
}
