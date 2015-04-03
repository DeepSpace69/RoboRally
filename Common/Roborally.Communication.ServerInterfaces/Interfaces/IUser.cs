namespace Roborally.Communication.ServerInterfaces
{
    /// <summary>The User interface.</summary>
    public interface IUser
    {
        #region Public Properties

        /// <summary>Gets the id.</summary>
        int ID { get; }

        /// <summary>Gets the name.</summary>
        string Name { get; }

        #endregion
    }
}