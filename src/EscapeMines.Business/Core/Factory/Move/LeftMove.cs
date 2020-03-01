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
    /// Represents the left move type
    /// </summary>
    public class LeftMove : IMove
    {
        public IPosition Move(IPosition position)
        {
            switch (position.Direction)
            {
                case Direction.North:
                    return new Position(new Coordinate(position.Coordinate.X, position.Coordinate.Y), Direction.West);
                case Direction.South:
                    return new Position(new Coordinate(position.Coordinate.X, position.Coordinate.Y), Direction.East);
                case Direction.East:
                    return new Position(new Coordinate(position.Coordinate.X, position.Coordinate.Y), Direction.North);
                case Direction.West:
                    return new Position(new Coordinate(position.Coordinate.X, position.Coordinate.Y), Direction.South);
                default:
                    throw new InvalidOperationException("Unsupported direction");
            }
        }
    }
}
