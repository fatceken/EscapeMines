using EscapeMines.Business.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeMines.Business.Utils
{
    /// <summary>
    /// Exposes useful conversion and parsing methods
    /// </summary>
    public class Conversion
    {
        /// <summary>
        /// Matches input direction value to its enum equivalent
        /// </summary>
        /// <param name="input">Single character string value, e.g. = "N" </param>
        /// <returns></returns>
        public static Direction GetDirection(string input)
        {
            if (input == "N")
            {
                return Direction.North;
            }
            else if (input == "W")
            {
                return Direction.West;
            }
            else if (input == "S")
            {
                return Direction.South;
            }
            else if (input == "E")
            {
                return Direction.East;
            }
            else
            {
                return Direction.Undefined;
            }
        }

        /// <summary>
        /// Matches input data move type value to its enum equivalent
        /// </summary>
        /// <param name="input">e.g.="L"</param>
        /// <returns></returns>
        public static MoveType GetMoveType(string input)
        {
            if (input == "L")
            {
                return MoveType.Left;
            }
            else if (input == "R")
            {
                return MoveType.Right;
            }
            else if (input == "M")
            {
                return MoveType.Forward;
            }
            else
            {
                return MoveType.Undefined;
            }
        }
    }
}
