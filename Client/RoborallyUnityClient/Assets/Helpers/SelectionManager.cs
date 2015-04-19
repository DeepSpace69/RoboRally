using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Helpers
{
    using UnityEngine;

    public static class SelectionManager
    {
        public static GameObject GetSelectedChild(GameObject panel)
        {
            GameObject result = null;

            var childCount = panel.transform.childCount;

            for (int i = 0; i < childCount; i++)
            {
                var child = panel.transform.GetChild(i).GetComponent<Animator>();
                if (child.GetBool("IsSelected"))
                {
                    result = child.gameObject;
                    break;
                }
            }

            return result;
        }
    }
}
