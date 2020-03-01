using EscapeMines.Business.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeMines.Business.Interfaces
{
    /// <summary>
    /// Represents a Turtle position
    /// </summary>
    public interface IPosition
    {
        /// <summary>
        /// Multi-dimension coordinate
        /// </summary>
        ICoordinate Coordinate { get; set; }

        /// <summary>
        /// The direction that the position is facing
        /// </summary>
        Direction Direction { get; set; }
    }
}
