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
            passwordDatabase = new PasswordDatabase();
            userDatabase = new UserDatabase();
            this.InitForTest();
        }

        private void InitForTest()
        {
            this.CreateNewUser("1", "1");
            this.userDatabase.AddUser(1, "1");
            this.passwordDatabase.AddPassword("1");
        }

        private PasswordDatabase passwordDatabase;
        private UserDatabase userDatabase;


        public IUser Login(string login, string password)
        {
            IUser result = null;
            User user = this.userDatabase.GetUser(login);
            bool isGenuine = this.passwordDatabase.UserIsGenuine(user.ID, password);
            if (isGenuine)
            {
                result = user;
            }

            return result;
        }

        public void CreateNewUser(string login, string password)
        {
            int id = this.passwordDatabase.AddPassword(login);
            this.userDatabase.AddUser(id, password);

        }
    }
}