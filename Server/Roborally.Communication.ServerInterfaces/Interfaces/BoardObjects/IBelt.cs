namespace Roborally.Communication.ServerInterfaces
{
    /// <summary>The Belt interface.</summary>
    public interface IBelt : IBoardObject
    {
        #region Public Properties

        /// <summary>Gets the direction.</summary>
        DirectionEnum Direction { get; }

        /// <summary>Gets the speed.</summary>
        int Speed { get; }

        /// <summary>Gets the type.</summary>
        BeltTypeEnum Type { get; }

        #endregion
    }
}