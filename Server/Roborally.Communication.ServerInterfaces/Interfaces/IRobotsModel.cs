namespace Roborally.Communication.ServerInterfaces
{
    /// <summary>The RobotsModel interface.</summary>
    public interface IRobotsModel
    {
        #region Public Properties

        /// <summary>Gets the id.</summary>
        int Id { get; }

        /// <summary>Gets the name.</summary>
        string Name { get; }

        #endregion
    }
}