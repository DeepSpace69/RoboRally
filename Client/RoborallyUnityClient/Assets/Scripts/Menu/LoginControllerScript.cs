using UnityEngine;
using UnityEngine.UI;

public class LoginControllerScript : MonoBehaviour
{
    public InputField LoginInputField;
    public InputField PasswordInputField;
    public ScreenManagerScript screenManager;

    public Animator loginView;
    public Animator mainMenu;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
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

    public void Logout()
    {
        this.screenManager.OpenPanel(this.loginView);
    }

    void OnLoginCompleted(bool isOk)
    {
        PhotonServer.Instance.LoginCompleted -= this.OnLoginCompleted;
        if (isOk)
        {
            this.screenManager.OpenPanel(this.mainMenu);
        }
    }
}
