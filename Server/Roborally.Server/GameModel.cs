using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roborally.Server
{
    public class GameModel
    {
        public void Start(int robotId, int mapId, int numberOfPlayers)
        {
            RobotsManager.Instance.GetRobotById(robotId);
            MapManager.Instance.GetMapById(mapId);
            //number of players?
        }
    }
}