namespace Roborally.Communication.ServerInterfaces
{
    /// <summary>The Register interface.</summary>
    public interface IRegister
    {
        #region Public Properties

        /// <summary>Gets the content.</summary>
        IOrderCard Content { get; }

        /// <summary>Gets a value indicating whether is available.</summary>
        bool IsAvailable { get; }

        #endregion
    }
}