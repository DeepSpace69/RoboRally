using UnityEngine;
using System.Collections;

public class ModelSelection : MonoBehaviour
{
    public GameObject Panel;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnRobotsModelClick()
    {

    }


    void OnMouseDown()
    {
        if (this.gameObject.tag == "Model1")
        {
            this.MovePanel(-108);
        }

        if (this.gameObject.tag == "Model2")
        {
            this.MovePanel(90);
        }
    }

    private void MovePanel(float newValue)
    {
        var oldPosition = this.Panel.transform.localPosition;
        oldPosition.x = newValue;
        this.Panel.transform.localPosition = oldPosition;
        CreateRobotMain.SelectedRobot = this.gameObject;
    }
}
