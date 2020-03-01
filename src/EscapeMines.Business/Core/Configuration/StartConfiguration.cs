using EscapeMines.Business.Core.Configuration.Interfaces;
using EscapeMines.Business.Enums;
using EscapeMines.Business.Interfaces;
using EscapeMines.Business.Models;
using EscapeMines.Business.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeMines.Business.Core.Configuration
{
    /// <summary>
    /// Holds information about the game start point configuration
    /// </summary>
    public class StartConfiguration : IStartConfiguration
    {
        private string Configuration = String.Empty;

        public IPosition GetStartPoint()
        {
            if (string.IsNullOrEmpty(Configuration))
            {
                throw new ArgumentNullException("configuration");
            }

            string[] splitted = Configuration.Split(Constants.Space);

            if (splitted.Length != 3)
            {
                throw new FormatException("GameConfiguration startPosition data is not in expected format. Ensure that the data is correct. Valid data format must be seperated two integers and direction. e.g. : 0 1 N");
            }

            int xPoint = 0;
            if (!int.TryParse(splitted[0], out xPoint))
            {
                throw new FormatException("GameConfiguration startPosition X data value must be an integer.");
            }

            int yPoint = 0;
            if (!int.TryParse(splitted[1], out yPoint))
            {
                throw new FormatException("GameConfiguration startPosition Y data value must be an integer.");
            }

            Direction direction = Conversion.GetDirection(splitted[2]);
            if (direction == Direction.Undefined)
            {
                throw new FormatException("GameConfiguration startPosition direction data value must be in one of (N,S,E,W).");
            }

            return new Position(new Coordinate(xPoint, yPoint), direction);
        }

        public StartConfiguration(string configuration)
        {
            this.Configuration = configuration;
        }
    }
}
