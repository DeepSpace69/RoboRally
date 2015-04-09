using System;
using System.Collections.Generic;
using Roborally.Communication.ServerInterfaces;

namespace Roborally.Server
{
    /// <summary>The main service.</summary>
    public class MainService : IMainService
    {

        public MainService()
        {
            loginManager = new LoginManager();
            gameModel = new GameModel();
        }

        private LoginManager loginManager;
        private GameModel gameModel;

        /// <summary>Gets information about what happens after performing actions of board objects.</summary>
        /// <param name="robots">The robots with new position and status.</param>
        public void BoardActions(IEnumerable<IGameRobot> robots)
        {
        }

        /// <summary>Create new robot for current user.</summary>
        /// <param name="robotModelId">The robot's model id.</param>
        /// <param name="name">The name of robot.</param>
        public void CreateRobot(int robotModelId, string name)
        {
            RobotsManager.Instance.CreateRobot(robotModelId, name);
        }

        /// <summary>Get cards for current turn.</summary>
        /// <returns>Collection of card for current turn.</returns>
        public IEnumerable<IOrderCard> GetCards()
        {
            return null;
        }

        /// <summary>Get current game info. Call each new turn.</summary>
        /// <returns>The object that represents all details about current game.</returns>
        public ICurrentGameInfo GetCurrentGameInfo()
        {
            return new CurrentGameInfo();
        }

        /// <summary>Get available maps for playing.</summary>
        /// <returns>Available maps for playing.</returns>
        public IEnumerable<IMap> GetMaps()
        {
           return MapManager.Instance.GetAllMaps();
        }

        /// <summary>Get robots of current user, that can play.</summary>
        /// <returns>Robots that can play.</returns>
        public IEnumerable<IRobot> GetMyRobots()
        {
            return RobotsManager.Instance.GetRobots();
        }

        /// <summary>Get ratings.</summary>
        /// <returns>Information about race, places, kills, etc.</returns>
        public IEnumerable<IRating> GetRatings()
        {
            return null;
        }

        /// <summary>Gets robots models.</summary>
        /// <returns>Available robots models.</returns>
        public IEnumerable<IRobotsModel> GetRobotsModels()
        {
            return RobotModelsManager.Instance.GetAllRobotModels();
        }

        /// <summary>Login into game.</summary>
        /// <param name="login">User's login.</param>
        /// <param name="password">User's password.</param>
        /// <returns>The <see cref="IUser"/>.</returns>
        public IUser Login(string login, string password)
        {
            // TODO эксепшен должен кидаться самим менеджером
            IUser result = loginManager.Login(login, password);
            if (result == null)
            {
                // TODO ArgumentNullException можно кидать только когда входящий аргумент налл, а не когда результат налл
                throw new ArgumentNullException();
            }
            return result;
        }

        /// <summary>Gets information about what happens after performing moving robots.</summary>
        /// <param name="robotId">Current players robot id.</param>
        /// <param name="robots">The robots.</param>
        public void MoveRobots(int robotId, IEnumerable<IGameRobot> robots)
        {
        }

        /// <summary>Start game.</summary>
        /// <param name="robotId">The robot id.</param>
        /// <param name="mapId">The map id.</param>
        /// <param name="numberOfPlayers">The number of players.</param>
        public void Play(int robotId, int mapId, int numberOfPlayers)
        {
            this.gameModel.Start(robotId, mapId, numberOfPlayers);
        }

        /// <summary>Performing power down - skip last turn.</summary>
        public void PowerDown()
        {
        }

        /// <summary>Place order cards into registers and send this info on server.</summary>
        /// <param name="registers">The registers with cards.</param>
        public void SetupRegisters(IEnumerable<IRegister> registers)
        {
        }

        /// <summary>Show content of current registers of all players.</summary>
        /// <param name="registers">Registers with their cards.</param>
        public void ShowRegister(IDictionary<string, IRegister> registers)
        {
        }
    }
}