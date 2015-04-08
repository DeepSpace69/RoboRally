using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roborally.Server
{
   internal class PasswordManager
    {
       public PasswordManager()
        {
            this.PasswordsDatabase = new Dictionary<int, string>();
            this.PasswordsDatabase.Add(0, "0");
        }

        private Dictionary<int, string> PasswordsDatabase;

        public bool UserIsGenuine(int id, string password)
        {
            bool result = false;

            if (password == this.PasswordsDatabase[id])
            {
                result = true;
            }
            return result;
        }

        public int AddPassword(string password)
        {
            int max = this.PasswordsDatabase.Keys.Max();
            int id = max + 1;
            this.PasswordsDatabase.Add(id, password);
            return id;
        }

        public void ChangePassword(int id, string password)
        {
            this.PasswordsDatabase[id] = password;
        }
    }
}
