using EscapeMines.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeMines.Business.Core.Configuration.Interfaces
{
    /// <summary>
    /// Represents the game start point configuration
    /// </summary>
    public interface IStartConfiguration
    {
        /// <summary>
        /// Creates the game start point from config
        /// </summary>
        /// <returns></returns>
        IPosition GetStartPoint();
    }
}
