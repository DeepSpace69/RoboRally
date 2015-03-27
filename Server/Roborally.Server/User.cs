using Roborally.Communication.ServerInterfaces;

namespace Roborally.Server
{
    public class User : IUser
    {
        public User(string id, string name)
        {
            this.ID = id;
            this.Name = name;
        }

        public string ID { get; set; }

        public string Name { get; set; }
    }
}