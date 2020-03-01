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
    /// Holds information about mines configuration
    /// </summary>
    public class MinesConfiguration : IMinesConfiguration
    {
        private string Configuration = String.Empty;

        public List<ICoordinate> GetMines()
        {
            if (string.IsNullOrEmpty(Configuration))
            {
                throw new FormatException("mines can not be null or empty");
            }

            string[] splittedMines = Configuration.Split(Constants.Space);

            if (splittedMines.Length < 1)
            {
                throw new FormatException("GameConfiguration mine data value is not in expected format. Ensure that the data is correct. Valid data format must be seperated cooridantes. e.g. : 1,1 1,3");
            }

            List<ICoordinate> resultList = new List<ICoordinate>();

            foreach (string splittedMine in splittedMines)
            {
                if (string.IsNullOrEmpty(splittedMine))
                {
                    throw new FormatException("GameConfiguration mine data values is not in expected format. Ensure that the data is correct. Valid data format must be seperated cooridantes. e.g. : 1,1");
                }

                string[] splittedMineCoordinates = splittedMine.Split(Constants.Comma);

                if (splittedMineCoordinates.Length != 2)
                {
                    throw new FormatException(string.Format("GameConfiguration mine data value : {0} is not in expected format. Ensure that the data is correct. Valid data format must be seperated cooridantes. e.g. : 1,1", splittedMine));
                }

                int splittedMineCoordinateX = 0;
                if (!int.TryParse(splittedMineCoordinates[0], out splittedMineCoordinateX))
                {
                    throw new FormatException(string.Format("GameConfiguration mine data value : {0} and X coordinate : {1} is not in expected format. Ensure that the data is correct. Valid data format must be seperated cooridantes. e.g. : 1,1", splittedMine, splittedMineCoordinates[0]));
                }

                int splittedMineCoordinateY = 0;
                if (!int.TryParse(splittedMineCoordinates[1], out splittedMineCoordinateY))
                {
                    throw new FormatException(string.Format("GameConfiguration mine data value : {0} and Y coordinate : {1} is not in expected format. Ensure that the data is correct. Valid data format must be seperated cooridantes. e.g. : 1,1", splittedMine, splittedMineCoordinates[1]));
                }

                resultList.Add(new Coordinate(splittedMineCoordinateX, splittedMineCoordinateY));
            }

            return resultList;
        }

        public MinesConfiguration(string configuration)
        {
            this.Configuration = configuration;
        }
    }
}
