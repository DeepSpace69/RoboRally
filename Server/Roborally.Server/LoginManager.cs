using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roborally.Communication.ServerInterfaces;

namespace Roborally.Server
{
    internal class LoginManager
    {
        public LoginManager()
        {
            passwordManager = new PasswordManager();
            userManager = new UserManager();
            this.InitForTest();
        }

        private void InitForTest()
        {
            this.CreateNewUser("1", "1");
            this.userManager.AddUser(1, "1");
            this.passwordManager.AddPassword("1");
        }

        private PasswordManager passwordManager;
        private UserManager userManager;


        public IUser Login(string login, string password)
        {
            IUser result = null;
            User user = this.userManager.GetUser(login);
            bool isGenuine = this.passwordManager.UserIsGenuine(user.ID, password);
            if (isGenuine)
            {
                result = user;
            }

            return result;
        }

        public void CreateNewUser(string login, string password)
        {
            int id = this.passwordManager.AddPassword(login);
            this.userManager.AddUser(id, password);
        }
    }
}