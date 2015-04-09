using System.Collections.Generic;

namespace Roborally.Communication.ServerInterfaces
{
    /// <summary>The Board interface.</summary>
    public interface IBoard
    {
        #region Public Properties

        /// <summary>Gets the board objects.</summary>
        IEnumerable<IBoardObject> BoardObjects { get; }

        /// <summary>Gets the map.</summary>
        IMap Map { get; }

        #endregion
    }
}