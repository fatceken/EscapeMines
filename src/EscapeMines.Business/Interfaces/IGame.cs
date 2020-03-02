using EscapeMines.Business.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeMines.Business.Interfaces
{
    /// <summary>
    /// Represents the game
    /// </summary>
    public interface IGame
    {
        /// <summary>
        /// Runs the game
        /// </summary>
        void Run();

        /// <summary>
        /// Gets the turtle of the game
        /// </summary>
        ITurtle Turtle { get; }

        /// <summary>
        /// Gets the result of the gamge
        /// </summary>
        List<Status> ResultList { get; }

        /// <summary>
        /// Gets the visited points of the turtle
        /// </summary>
        List<List<IPosition>> VisitedPositions { get; }
    }
}
