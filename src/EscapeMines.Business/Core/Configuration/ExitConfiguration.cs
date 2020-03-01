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
    /// Holds information about game exit point configuration
    /// </summary>
    public class ExitConfiguration : IExitConfiguration
    {
        private string Configuration = String.Empty;

        public ICoordinate GetExitPoint()
        {
            if (string.IsNullOrEmpty(Configuration))
            {
                throw new ArgumentNullException("configuration");
            }

            string[] splitted = Configuration.Split(Constants.Space);

            if (splitted.Length != 2)
            {
                throw new FormatException("GameConfiguration exit data is not in expected format. Ensure that the data is correct. Valid data format must be seperated two integers. e.g. : 5 5");
            }

            int xPoint = 0;
            if (!int.TryParse(splitted[0], out xPoint))
            {
                throw new FormatException("GameConfiguration exit X data value must be an integer.");
            }

            int yPoint = 0;
            if (!int.TryParse(splitted[1], out yPoint))
            {
                throw new FormatException("GameConfiguration exit Y data value must be an integer.");
            }

            return new Coordinate(xPoint, yPoint);
        }

        public ExitConfiguration(string configuration)
        {
            this.Configuration = configuration;
        }
    }
}
