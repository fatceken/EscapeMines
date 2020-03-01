using EscapeMines.Business.Core.Configuration.Interfaces;
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
    /// Holds information about the game board configuration
    /// </summary>
    public class BoardConfiguration : IBoardConfiguration
    {
        private string Configuration = String.Empty;

        public IBoard GetBoard()
        {
            if (string.IsNullOrEmpty(Configuration))
            {
                throw new ArgumentNullException("Configuration");
            }

            string[] splitted = Configuration.Split(Constants.Space);

            if (splitted.Length != 2)
            {
                throw new FormatException("GameConfiguration BoardMax data is not in expected format. Ensure that the data is correct. Valid data format must be seperated two integers. e.g. : 5 5");
            }

            int maximumXPoint = 0;
            if (!int.TryParse(splitted[0], out maximumXPoint))
            {
                throw new FormatException("GameConfiguration BoardMax X data value must be an integer.");
            }

            int maximumYPoint = 0;
            if (!int.TryParse(splitted[1], out maximumYPoint))
            {
                throw new FormatException("GameConfiguration BoardMax Y data value must be an integer.");
            }

            return new Board(new Coordinate(0, 0), new Coordinate(maximumXPoint - 1, maximumYPoint - 1));
        }

        public BoardConfiguration(string configuration)
        {
            this.Configuration = configuration;
        }
    }
}
