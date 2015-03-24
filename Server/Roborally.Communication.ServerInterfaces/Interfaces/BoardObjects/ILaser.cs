namespace Roborally.Communication.ServerInterfaces
{
    /// <summary>The Laser interface.</summary>
    public interface ILaser : IBoardObject
    {
        #region Public Properties

        /// <summary>Gets the power.</summary>
        int Power { get; }

        #endregion
    }
}