using System;
using System.Collections;

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>The screen manager.</summary>
public class ScreenManagerScript : MonoBehaviour
{
    // Screen to open automatically at the start of the Scene
    public Animator initiallyOpen;

    private Animator lastOpened;

    public void OnEnable()
    {
        //If set, open the initial Screen now.
        if (initiallyOpen == null)
            return;
        OpenPanel(initiallyOpen);
    }

    //Closes the currently open panel and opens the provided one.
    //It also takes care of handling the navigation, setting the new Selected element.
    public void OpenPanel(Animator anim)
    {
        if (anim == null)
        {
            return;
        }

        if (this.lastOpened != null)
        {
            this.lastOpened.SetBool("IsOpened", false);
            //this.lastOpened.gameObject.SetActive(false);
            StartCoroutine(DisablePanelDeleyed(this.lastOpened, () => this.OpenPanelInternal(anim)));
        }
        else
        {
            this.OpenPanelInternal(anim);
        }
    }

    private void OpenPanelInternal(Animator anim)
    {
        anim.gameObject.SetActive(true);
        anim.SetBool("IsOpened", true);
        this.lastOpened = anim;
    }

    //Coroutine that will detect when the Closing animation is finished and it will deactivate the
    //hierarchy.
    IEnumerator DisablePanelDeleyed(Animator anim, Action continueWith)
    {
        bool closedStateReached = false;
        while (!closedStateReached)
        {
            if (!anim.IsInTransition(0))
            {
                closedStateReached = anim.GetCurrentAnimatorStateInfo(0).IsName("Closed");
            }

            yield return new WaitForEndOfFrame();
        }

        anim.gameObject.SetActive(false);
        continueWith();
    }
}