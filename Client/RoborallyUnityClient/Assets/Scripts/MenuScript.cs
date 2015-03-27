using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public InputField LoginInputField;
    public InputField PasswordInputField;



    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PhotonServer.Instance.Update(Debug.Log);        
    }

    void OnGUI()
    {

        GUI.Label(new Rect(5, 30, 100, 20), PhotonServer.Instance.Status);
    }

    public void Connect()
    {
        PhotonServer.Instance.Connect();
    }

    public void OnLoginButtonClick()
    {
        var login = this.LoginInputField.text;
        var pass = this.PasswordInputField.text;
        PhotonServer.Instance.Login(login, pass);
    }
}
