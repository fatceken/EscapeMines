using EscapeMines.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeMines.Business.Core.Configuration.Interfaces
{
    /// <summary>
    /// Represents the game exit point configuration
    /// </summary>
    public interface IExitConfiguration
    {
        /// <summary>
        /// Creates the exit point from config
        /// </summary>
        /// <returns></returns>
        ICoordinate GetExitPoint();
    }
}
