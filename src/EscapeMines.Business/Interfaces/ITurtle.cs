using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeMines.Business.Interfaces
{
    /// <summary>
    /// Represents a turtle
    /// </summary>
    public interface ITurtle
    {
        /// <summary>
        /// Gets the current position on Board
        /// </summary>
        IPosition CurrentPosition { get; set; }
    }
}
