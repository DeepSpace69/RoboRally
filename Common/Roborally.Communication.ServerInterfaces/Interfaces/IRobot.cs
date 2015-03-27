namespace Roborally.Communication.ServerInterfaces
{
    /// <summary>The Robot interface.</summary>
    public interface IRobot
    {
        #region Public Properties

        /// <summary>Gets the id.</summary>
        int Id { get; }

        /// <summary>Gets the model id.</summary>
        int ModelId { get; }

        /// <summary>Gets the name.</summary>
        string Name { get; }

        #endregion
    }
}