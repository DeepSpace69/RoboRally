namespace Roborally.Communication.ServerInterfaces
{
    /// <summary>The Rating interface.</summary>
    public interface IRating
    {
        #region Public Properties

        /// <summary>Gets a value indicating whether is alive.</summary>
        bool IsAlive { get; }

        /// <summary>Gets the robot id.</summary>
        int RobotId { get; }

        #endregion
    }
}