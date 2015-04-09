using System.Collections.Generic;

namespace Roborally.Communication.ServerInterfaces
{
    /// <summary>The Main service interface.</summary>
    public interface IMainService
    {
        #region Public Methods and Operators

        /// <summary>Gets information about what happens after performing actions of board objects.</summary>
        /// <param name="robots">The robots with new position and status.</param>
        void BoardActions(IEnumerable<IGameRobot> robots);

        /// <summary>Create new robot for current user.</summary>
        /// <param name="robotModelId">The robot's model id.</param>
        /// <param name="name">The name of robot.</param>
        void CreateRobot(int robotModelId, string name);

        /// <summary>Get cards for current turn.</summary>
        /// <returns>Collection of card for current turn.</returns>
        IEnumerable<IOrderCard> GetCards();

        /// <summary>Get current game info. Call each new turn.</summary>
        /// <returns>The object that represents all details about current game.</returns>
        ICurrentGameInfo GetCurrentGameInfo();

        /// <summary>Get available maps for playing.</summary>
        /// <returns>Available maps for playing.</returns>
        IEnumerable<IMap> GetMaps();

        /// <summary>Get robots of current user, that can play.</summary>
        /// <returns>Robots that can play.</returns>
        IEnumerable<IRobot> GetMyRobots();

        /// <summary>Get ratings.</summary>
        /// <returns>Information about race, places, kills, etc.</returns>
        IEnumerable<IRating> GetRatings();

        /// <summary>Gets robots models.</summary>
        /// <returns>Available robots models.</returns>
        IEnumerable<IRobotsModel> GetRobotsModels();

        /// <summary>Login into game.</summary>
        /// <param name="login">User's login.</param>
        /// <param name="password">User's password.</param>
        /// <returns>The <see cref="IUser"/>.</returns>
        IUser Login(string login, string password);

        /// <summary>Gets information about what happens after performing moving robots.</summary>
        /// <param name="robotId">Current players robot id.</param>
        /// <param name="robots">The robots.</param>
        void MoveRobots(int robotId, IEnumerable<IGameRobot> robots);

        /// <summary>Start game.</summary>
        /// <param name="robotId">The robot id.</param>
        /// <param name="mapId">The map id.</param>
        /// <param name="numberOfPlayers">The number of players.</param>
        void Play(int robotId, int mapId, int numberOfPlayers);

        /// <summary>Performing power down - skip last turn.</summary>
        void PowerDown();

        /// <summary>Place order cards into registers and send this info on server.</summary>
        /// <param name="registers">The registers with cards.</param>
        void SetupRegisters(IEnumerable<IRegister> registers);

        /// <summary>Show content of current registers of all players.</summary>
        /// <param name="registers">Registers with their cards.</param>
        void ShowRegister(IDictionary<string, IRegister> registers);

        #endregion
    }
}