using EscapeMines.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeMines.Business.Core.Factory.Move
{
    /// <summary>
    /// Represents a move
    /// </summary>
    public interface IMove
    {
        /// <summary>
        /// Moves input position to new position
        /// </summary>
        /// <param name="position">position to be moved</param>
        /// <returns>moved position</returns>
        IPosition Move(IPosition position);
    }
}
