namespace Roborally.Communication.ServerInterfaces
{
    /// <summary>The Register interface.</summary>
    public interface IRegister
    {
        #region Public Properties

        /// <summary>
        /// Register identifier (number)
        /// </summary>
        string ID { get; }

        /// <summary>Gets the content.</summary>
        IOrderCard Content { get; set; }

        /// <summary>Gets a value indicating whether is available.</summary>
        bool IsAvailable { get; }

        #endregion
    }
}