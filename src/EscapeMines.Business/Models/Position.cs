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
    /// Holds information about a position
    /// </summary>
    public class Position : IPosition
    {
        public ICoordinate Coordinate { get; set; }
        public Direction Direction { get; set; }

        public Position(ICoordinate coordinate, Direction direction)
        {
            if (coordinate == null)
            {
                throw new ArgumentNullException("coordinate");
            }

            if (direction == Direction.Undefined)
            {
                throw new FormatException("Direction is undefined");
            }

            this.Coordinate = coordinate;
            this.Direction = direction;
        }
    }
}
