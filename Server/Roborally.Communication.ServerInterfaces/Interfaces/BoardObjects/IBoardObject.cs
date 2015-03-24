namespace Roborally.Communication.ServerInterfaces
{
    /// <summary>The BoardObject interface.</summary>
    public interface IBoardObject
    {
        #region Public Properties

        /// <summary>Gets the position.</summary>
        IPosition Position { get; }

        #endregion
    }
}