using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Menu
{
    using Roborally.Communication.Data.DataContracts;

    using UnityEngine;
    using UnityEngine.UI;

    public abstract class BaseObjectLoader : MonoBehaviour
    {
        public GameObject GameObjectSelector;

        public BaseScreenController baseScreenController;

        void Awake()
        {
            this.baseScreenController.OnScreenShowed += this.OnScreenShowed;
            this.baseScreenController.OnScreenHidden += this.OnScreenHidden;
        }

        private void OnScreenHidden()
        {
            this.CleanPanel();
        }

        private void OnScreenShowed()
        {
            this.CleanPanel();
            this.LoadObjects();
        }

        private void CleanPanel()
        {
            for (int i = this.gameObject.transform.childCount - 1; i >= 0; i--)
            {
                var robot = this.gameObject.transform.GetChild(i).gameObject;
                Destroy(robot);
            }
        }

        public abstract void LoadObjects();

        protected GameObject CreateGameObject(object model)
        {
            var uiObject = Instantiate(this.GameObjectSelector);
            GameObjectRepository.Register(uiObject, model);
            uiObject.transform.SetParent(this.gameObject.transform);
            uiObject.transform.localScale = new Vector3(1, 1, 1);
            return uiObject;
        }
    }
}
