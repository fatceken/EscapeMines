using EscapeMines.Business.Enums;
using EscapeMines.Business.Interfaces;
using EscapeMines.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeMines.Business.Core.Factory.Move
{
    /// <summary>
    /// Represents the right move type
    /// </summary>
    public class RightMove : IMove
    {
        public IPosition Move(IPosition position)
        {
            switch (position.Direction)
            {
                case Direction.North:
                    return new Position(new Coordinate(position.Coordinate.X, position.Coordinate.Y), Direction.East);
                case Direction.South:
                    return new Position(new Coordinate(position.Coordinate.X, position.Coordinate.Y), Direction.West);
                case Direction.East:
                    return new Position(new Coordinate(position.Coordinate.X, position.Coordinate.Y), Direction.South);
                case Direction.West:
                    return new Position(new Coordinate(position.Coordinate.X, position.Coordinate.Y), Direction.North);
                default:
                    throw new InvalidOperationException("Unsupported direction");
            }
        }
    }
}
