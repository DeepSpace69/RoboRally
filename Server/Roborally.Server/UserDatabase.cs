using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roborally.Server
{
    internal class UserDatabase
    {
        public UserDatabase()
        {
            this.AllUsers = new List<User>();
        }
        private List<User> AllUsers { get; set; }

        public User GetUser(string login)
        {
            User user = null;
            foreach (var item in this.AllUsers)
            {
                if (item.Name == login)
                {
                    user = item;
                }
            }

            return user;
        }

        public void AddUser(int id, string name)
        {
            User user = new User(id, name);

            this.AllUsers.Add(user);
        }
    }
}
