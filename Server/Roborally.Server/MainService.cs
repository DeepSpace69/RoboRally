using System.Collections.Generic;

using Roborally.Communication.ServerInterfaces;

namespace Roborally.Server
{
    /// <summary>The main service.</summary>
    public class MainService : IMainService
    {
        /// <summary>Gets information about what happens after performing actions of board objects.</summary>
        /// <param name="robots">The robots with new position and status.</param>
        public void BoardActions(ICollection<IGameRobot> robots)
        {
        }

        /// <summary>Create new robot for current user.</summary>
        /// <param name="robotModelId">The robot's model id.</param>
        /// <param name="name">The name of robot.</param>
        public void CreateRobot(int robotModelId, string name)
        {
        }

        /// <summary>Get cards for current turn.</summary>
        /// <returns>Collection of card for current turn.</returns>
        public ICollection<IOrderCard> GetCards()
        {
            return null;
        }

        /// <summary>Get current game info. Call each new turn.</summary>
        /// <returns>The object that represents all details about current game.</returns>
        public ICurrentGameInfo GetCurrentGameInfo()
        {
            return null;
        }

        /// <summary>Get available maps for playing.</summary>
        /// <returns>Available maps for playing.</returns>
        public ICollection<IMap> GetMaps()
        {
            return null;
        }

        /// <summary>Get robots of current user, that can play.</summary>
        /// <returns>Robots that can play.</returns>
        public ICollection<IRobot> GetMyRobots()
        {
            return null;
        }

        /// <summary>Get ratings.</summary>
        /// <returns>Information about race, places, kills, etc.</returns>
        public ICollection<IRating> GetRatings()
        {
            return null;
        }

        /// <summary>Gets robots models.</summary>
        /// <returns>Available robots models.</returns>
        public ICollection<IRobotsModel> GetRobotsModels()
        {
            return null;
        }

        /// <summary>Login into game.</summary>
        /// <param name="login">User's login.</param>
        /// <param name="password">User's password.</param>
        /// <returns>The <see cref="IUser"/>.</returns>
        public IUser Login(string login, string password)
        {
            return null;
        }

        /// <summary>Gets information about what happens after performing moving robots.</summary>
        /// <param name="robotId">Current players robot id.</param>
        /// <param name="robots">The robots.</param>
        public void MoveRobots(int robotId, ICollection<IGameRobot> robots)
        {
        }

        /// <summary>Start game.</summary>
        /// <param name="robotId">The robot id.</param>
        /// <param name="mapId">The map id.</param>
        /// <param name="numberOfPlayers">The number of players.</param>
        public void Play(int robotId, int mapId, int numberOfPlayers)
        {
        }

        /// <summary>Performing power down - skip last turn.</summary>
        public void PowerDown()
        {
        }

        /// <summary>Place order cards into registers and send this info on server.</summary>
        /// <param name="registers">The registers with cards.</param>
        public void SetupRegisters(ICollection<IRegister> registers)
        {
        }

        /// <summary>Show content of current registers of all players.</summary>
        /// <param name="registers">Registers with their cards.</param>
        public void ShowRegister(IDictionary<string, IRegister> registers)
        {
        }
    }
}
