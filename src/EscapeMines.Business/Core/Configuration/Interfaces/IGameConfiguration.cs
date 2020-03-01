using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeMines.Business.Core.Configuration.Interfaces
{
    /// <summary>
    /// Represents the game configuration
    /// </summary>
    public interface IGameConfiguration
    {
        /// <summary>
        /// Gets the board configuration of the game
        /// </summary>
        IBoardConfiguration BoardConfiguration { get; }

        /// <summary>
        /// Gets the mines configuration of the game
        /// </summary>
        IMinesConfiguration MinesConfiguration { get; }

        /// <summary>
        /// Gets the exit point configuration of the game
        /// </summary>
        IExitConfiguration ExitConfiguration { get; }

        /// <summary>
        /// Gets the start point configuration of the game
        /// </summary>
        IStartConfiguration StartConfiguration { get; }

        /// <summary>
        /// Gets the moves configuration of the game
        /// </summary>
        IMoveConfiguration MoveConfiguration { get; }

        /// <summary>
        /// Gets true if the configuration is done, otherwise false
        /// </summary>
        bool IsConfigured { get; }
    }
}
