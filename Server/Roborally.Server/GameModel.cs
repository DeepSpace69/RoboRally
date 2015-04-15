using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roborally.Communication.ServerInterfaces;

namespace Roborally.Server
{
    public class GameModel
    {
        private Robot currentRobot;
        private Map currentMap;
        private List<User> allUsers;
        private User currentUser;
        private CurrentGameInfo currentGameInfo;

        public void Start(int robotId, int mapId, int numberOfPlayers, User incomingUser)
        {
            this.currentRobot = RobotsManager.Instance.GetRobotById(robotId) as Robot; //??
            this.currentMap = MapManager.Instance.GetMapById(mapId) as Map; //??
            this.currentUser = incomingUser;
            this.allUsers = new List<User>();
        }

        public ICurrentGameInfo GetCurrentGameInfo()
        {
            if (currentGameInfo == null)
            {
                currentGameInfo = new CurrentGameInfo();
            }
            return currentGameInfo;
        }
    }
}