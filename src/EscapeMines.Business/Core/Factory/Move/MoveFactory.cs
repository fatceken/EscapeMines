using EscapeMines.Business.Enums;
using EscapeMines.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeMines.Business.Core.Factory.Move
{
    /// <summary>
    /// Factory class for managing move types 
    /// </summary>
    public class MoveFactory
    {
        /// <summary>
        /// Creates appropriate move according to input type
        /// </summary>
        /// <param name="moveType"></param>
        /// <returns></returns>
        public IMove GetMove(MoveType moveType)
        {
            switch (moveType)
            {
                case MoveType.Right:
                    return new RightMove();
                case MoveType.Left:
                    return new LeftMove();
                case MoveType.Forward:
                    return new ForwardMove();
            }
            return new NullMove();
        }
    }
}
