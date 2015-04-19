using UnityEngine;
using System.Collections;

using Assets.Scripts.Menu;
using System.Collections.Generic;

using Roborally.Communication.Data.DataContracts;

using UnityEngine.UI;

public class LoadMapsScript : BaseObjectLoader
{
    public override void LoadObjects()
    {
        PhotonServer.Instance.GetMapsCompleted += this.OnGetMapsCompleted;
        PhotonServer.Instance.GetMaps();
    }

    private void OnGetMapsCompleted(List<PhotonMap> maps)
    {
        PhotonServer.Instance.GetMapsCompleted -= this.OnGetMapsCompleted;
        this.ShowMaps(maps);
    }

    private void ShowMaps(List<PhotonMap> maps)
    {
        foreach (var photonMap in maps)
        {
            var uiMap = this.CreateGameObject(photonMap);
            var image = uiMap.transform.GetChild(0).GetComponent<Image>();
            var imageMap = Resources.Load<Sprite>("Images/Maps/map" + photonMap.Id);
            image.sprite = imageMap;
            var nameTextBlock = uiMap.GetComponentInChildren<Text>();
            nameTextBlock.text = photonMap.Name;
        }
    }
}
