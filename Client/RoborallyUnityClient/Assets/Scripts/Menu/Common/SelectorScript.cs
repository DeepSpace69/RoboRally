using UnityEngine;
using System.Collections;

public class SelectorScript : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnSelected()
    {
        var parentPanel = this.gameObject.transform.parent;
        var childCount = parentPanel.childCount;

        for (int i = 0; i < childCount; i++)
        {
            var child = parentPanel.GetChild(i).gameObject;
            child.GetComponent<Animator>().SetBool("IsSelected", false);
        }

        this.gameObject.GetComponent<Animator>().SetBool("IsSelected", true);
    }
}
