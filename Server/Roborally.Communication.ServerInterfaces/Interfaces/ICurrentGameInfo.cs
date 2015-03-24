using System.Collections.Generic;

namespace Roborally.Communication.ServerInterfaces
{
    /// <summary>The CurrentGameInfo interface.</summary>
    public interface ICurrentGameInfo
    {
        #region Public Properties

        /// <summary>Gets the board.</summary>
        IBoard Board { get; }

        /// <summary>Gets the current state.</summary>
        GameStateEnum CurrentState { get; }

        /// <summary>Gets the game robots.</summary>
        ICollection<IGameRobot> GameRobots { get; }

        /// <summary>Gets the registers.</summary>
        ICollection<IRegister> Registers { get; }

        #endregion
    }
}