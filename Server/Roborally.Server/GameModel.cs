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
        private User currentUser;

        public void Start(int robotId, int mapId, int numberOfPlayers, User incomingUser)
        {
            this.currentRobot = RobotsManager.Instance.GetRobotById(robotId) as Robot; //??
            this.currentMap = MapManager.Instance.GetMapById(mapId) as Map; //??
            this.currentUser = incomingUser;
            //number of players?





        }
    }
}