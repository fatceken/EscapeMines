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
    /// Represents the forward move type
    /// </summary>
    public class ForwardMove : IMove
    {
        public IPosition Move(IPosition position)
        {
            switch (position.Direction)
            {
                case Direction.North:
                    return new Position(new Coordinate(position.Coordinate.X, position.Coordinate.Y + 1), position.Direction);
                case Direction.South:
                    return new Position(new Coordinate(position.Coordinate.X, position.Coordinate.Y - 1), position.Direction);
                case Direction.East:
                    return new Position(new Coordinate(position.Coordinate.X + 1, position.Coordinate.Y), position.Direction);
                case Direction.West:
                    return new Position(new Coordinate(position.Coordinate.X - 1, position.Coordinate.Y), position.Direction);
                default:
                    throw new InvalidOperationException("Unsupported direction");
            }
        }
    }
}
