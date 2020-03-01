using EscapeMines.Business.Interfaces;
using EscapeMines.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeMines.Business.Core.Configuration.Interfaces
{
    /// <summary>
    /// Represents the game board configuration
    /// </summary>
    public interface IBoardConfiguration
    {
        /// <summary>
        /// Creates the board from config
        /// </summary>
        /// <returns></returns>
        IBoard GetBoard();
    }
}
