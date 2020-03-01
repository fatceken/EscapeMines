using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeMines.Business.Interfaces
{
    /// <summary>
    /// Represents the game board
    /// </summary>
    public interface IBoard
    {
        /// <summary>
        /// Maximum point of the game board
        /// </summary>
        ICoordinate Max { get; }

        /// <summary>
        /// Minimum point of the game board
        /// </summary>
        ICoordinate Min { get; }

        /// <summary>
        /// Checks the input coordinate is in the game board.
        /// </summary>
        /// <param name="coordinate">coordinate to be checked</param>
        /// <returns></returns>
        bool IsInBoard(ICoordinate coordinate);
    }
}
