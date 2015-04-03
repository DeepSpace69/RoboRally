using Roborally.Communication.ServerInterfaces;

namespace Roborally.Server
{
    public class User : IUser
    {
        public User(int id, string name)
        {
            this.ID = id;
            this.Name = name;
        }

        public int ID { get; set; }

        public string Name { get; set; }
    }
}