using EscapeMines.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeMines.Business.Core.Configuration.Interfaces
{
    /// <summary>
    /// Represents the mine positions configuration
    /// </summary>
    public interface IMinesConfiguration
    {
        /// <summary>
        /// Gets the position of mines
        /// </summary>
        /// <returns></returns>
        List<ICoordinate> GetMines();
    }
}
