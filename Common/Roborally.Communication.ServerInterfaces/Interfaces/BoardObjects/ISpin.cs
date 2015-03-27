namespace Roborally.Communication.ServerInterfaces
{
    /// <summary>The Spin interface.</summary>
    public interface ISpin : IBoardObject
    {
        #region Public Properties

        /// <summary>Gets the direction.</summary>
        SpinDirectionEnum Direction { get; }

        /// <summary>Gets the speed.</summary>
        int Speed { get; }

        #endregion
    }
}