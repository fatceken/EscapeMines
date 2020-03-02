using EscapeMines.Business.Enums;
using EscapeMines.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeMines.Business.Models
{
    /// <summary>
    /// Holds information about the game result
    /// </summary>
    public class GameResult
    {
        /// <summary>
        /// Gets the game result list for each iteration
        /// </summary>
        public List<Status> ResultList { get; private set; }

        /// <summary>
        /// Gets the visited positions of the Turtle for each iteration
        /// </summary>
        public List<List<IPosition>> VisitedPositions { get; private set; }

        public GameResult(int iterationCount)
        {
            ResultList = new List<Status>(iterationCount);
            VisitedPositions = new List<List<IPosition>>(iterationCount);
        }
    }
}
