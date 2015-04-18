using System;

using UnityEngine;
using System.Collections;

public class BaseScreenController : MonoBehaviour
{
    public event Action OnScreenShowed;

    public event Action OnScreenHidden;

    public void OnShowScreen()
    {
        this.RaiseEvent(this.OnScreenShowed);
    }

    public void OnHideScreen()
    {
        this.RaiseEvent(this.OnScreenHidden);
    }

    private void RaiseEvent(Action someEvent)
    {
        if (someEvent != null)
        {
            someEvent();
        }
    }
}
