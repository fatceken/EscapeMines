using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeMines.Business.Enums
{
    /// <summary>
    /// Represents the current Status Of Turtle
    /// </summary>
    public enum Status
    {
        Undefined,
        Success,
        MineHit,
        StillInDanger,
        OutOfBoard
    }
}
