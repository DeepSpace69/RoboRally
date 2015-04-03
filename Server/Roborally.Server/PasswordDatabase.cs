using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roborally.Server
{
    internal class PasswordDatabase
    {
        public PasswordDatabase()
        {
            this.AllPasswords = new Dictionary<int, string>();
            this.AllPasswords.Add(0, "0");
        }

        private Dictionary<int, string> AllPasswords;

        public bool UserIsGenuine(int id, string password)
        {
            bool result = false;

            if (password == this.AllPasswords[id])
            {
                result = true;
            }
            return result;
        }

        public int AddPassword(string password)
        {
            int max = this.AllPasswords.Keys.Max();
            int id = max + 1;
            this.AllPasswords.Add(id, password);
            return id;
        }

        public void ChangePassword(int id, string password)
        {
            this.AllPasswords[id] = password;
        }

    }
}