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
        PhotonServer.Instance.Update();
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
        PhotonServer.Instance.LoginCompleted += this.OnLoginCompleted;
        PhotonServer.Instance.Login(login, pass);
    }

    void OnLoginCompleted(bool isOk)
    {
        PhotonServer.Instance.LoginCompleted -= this.OnLoginCompleted;
        if (isOk)
        {
            Application.LoadLevelAsync("MenuScene");
        }
    }
}
