namespace Roborally.Communication.ServerInterfaces
{
    /// <summary>The GameRobot interface.</summary>
    public interface IGameRobot : IBoardObject
    {
        #region Public Properties

        /// <summary>Gets the current direction.</summary>
        DirectionEnum CurrentDirection { get; }

        /// <summary>Gets the health point.</summary>
        int HealthPoint { get; }

        /// <summary>Gets a value indicating whether is power down.</summary>
        bool IsPowerDown { get; }

        /// <summary>Gets the life amount.</summary>
        int LifeAmount { get; }

        /// <summary>Gets the robot id.</summary>
        int RobotId { get; }

        /// <summary>Gets the robots model.</summary>
        IRobotsModel RobotsModel { get; }

        /// <summary>
        /// Gets name of robots
        /// </summary>
        string Name { get; }

        #endregion
    }
}