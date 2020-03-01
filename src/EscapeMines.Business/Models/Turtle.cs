using EscapeMines.Business.Enums;
using EscapeMines.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeMines.Business.Models
{
    /// <summary>
    /// Holds information of a Turtle
    /// </summary>
    public class Turtle : ITurtle
    {
        public IPosition CurrentPosition { get; set; }

        public Turtle(IPosition currentPosition)
        {
            if (currentPosition == null)
            {
                throw new ArgumentNullException("currentPosition");
            }

            this.CurrentPosition = currentPosition;
        }
    }
}
