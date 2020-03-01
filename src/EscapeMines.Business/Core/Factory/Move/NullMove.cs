using EscapeMines.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeMines.Business.Core.Factory.Move
{
    /// <summary>
    /// Represents an invalid move
    /// </summary>
    public class NullMove : IMove
    {
        public IPosition Move(IPosition position)
        {
            return position;
        }
    }
}
