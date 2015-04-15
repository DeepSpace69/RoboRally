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
            // TODO Абстракции - интерфейсы и абстрактные классы, позволяют тебе изолировать реализацию.
            // Другие сущности, будучи зависимыми от интерфейсов, не почувствуют, если ты полностью 
            // заменишь один класс на другой, если они реализуют один и тот же интерфейс

            // Когда ты делаешь такого рода приведения, ты начисто лишаешь смысла использование интерфейсов. С тем же успехом метод 
            // GetRobotById() мог бы возвращать не IRobot, а просто Robot. А если ты захочешь добавить новый функционал, и скажем сделать нового робота
            // который реализует интерфейс IRobot но умеет ещё и получать экспу за убийства ExpRobot:Irobot - то твоя модель не сможет с ним работать, потому что будет
            // пытаться привести его к типу Robot
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
            // number of players - это кол-во игроков (ботов) на карте.
        }
    }
}