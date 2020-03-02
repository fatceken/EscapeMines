using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeMines.Business.Interfaces
{
    /// <summary>
    /// Represents a validatior for game
    /// </summary>
    public interface IGameValidator
    {
        /// <summary>
        /// Validates game settings, if any validation fails throws exception
        /// </summary>
        void Validate();
    }
}
