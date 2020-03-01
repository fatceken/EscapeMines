using EscapeMines.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeMines.Business.Models
{
    /// <summary>
    /// Holds information of a game board
    /// </summary>
    public class Board : IBoard
    {
        public ICoordinate Max { get; private set; }
        public ICoordinate Min { get; private set; }

        /// <summary>
        /// Checks if a coordinate in is board
        /// </summary>
        /// <param name="coordinate">coordinate to check</param>
        /// <returns></returns>
        public bool IsInBoard(ICoordinate coordinate)
        {
            if (coordinate == null)
            {
                throw new ArgumentNullException("coordinate");
            }

            return coordinate.X <= Max.X && coordinate.Y <= Max.Y && coordinate.X >= Min.X && coordinate.Y >= Min.Y;
        }

        /// <summary>
        /// Creates a game board with given coordinates.
        /// </summary>
        /// <param name="min">Minimum coordinate of board</param>
        /// <param name="max">Maximum coordinate of board</param>
        public Board(ICoordinate min, ICoordinate max)
        {
            if (min == null)
            {
                throw new ArgumentNullException("min");
            }

            if (max == null)
            {
                throw new ArgumentNullException("max");
            }

            this.Max = max;
            this.Min = min;
        }
    }
}
