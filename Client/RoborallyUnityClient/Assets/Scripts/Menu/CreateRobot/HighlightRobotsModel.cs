using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class HighlightRobotsModel : MonoBehaviour
{
    public void SetSelected(GameObject selectedItem)
    {
        var total = this.gameObject.transform.childCount;

        for (int i = total - 1; i >= 0; i--)
        {
            var child = this.gameObject.transform.GetChild(i).gameObject;
            var image = child.GetComponent<Image>();
            if (child != selectedItem)
            {
                image.color = Color.white;
            }
            else
            {
                image.color = Color.blue;
            }
        }
    }
}
