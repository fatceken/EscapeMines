using EscapeMines.Business.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeMines.Business.Core.Configuration.Interfaces
{
    /// <summary>
    /// Represents the configuration of moves that will be executed
    /// </summary>
    public interface IMoveConfiguration
    {
        /// <summary>
        /// Creates the moves as a list of MoveType
        /// </summary>
        /// <returns></returns>
        List<List<MoveType>> GetMoves();
    }
}
