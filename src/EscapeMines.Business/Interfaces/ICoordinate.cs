using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeMines.Business.Interfaces
{
    /// <summary>
    /// Represents a two dimensional point.
    /// </summary>
    public interface ICoordinate
    {
        /// <summary>
        /// Horizontal dimension of point
        /// </summary>
        int X { get; set; }

        /// <summary>
        /// Vertical dimension of point
        /// </summary>
        int Y { get; set; }
    }
}
