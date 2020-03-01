using EscapeMines.Business.Core.Configuration.Interfaces;
using EscapeMines.Business.Enums;
using EscapeMines.Business.Interfaces;
using EscapeMines.Business.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EscapeMines.Business.Core.Configuration
{
    /// <summary>
    /// Holds information about game configuration
    /// </summary>
    public class GameConfiguration : IGameConfiguration
    {
        public IBoardConfiguration BoardConfiguration { get; private set; }
        public IMinesConfiguration MinesConfiguration { get; private set; }
        public IExitConfiguration ExitConfiguration { get; private set; }
        public IStartConfiguration StartConfiguration { get; private set; }
        public IMoveConfiguration MoveConfiguration { get; private set; }
        public bool IsConfigured { get; private set; }

        /// <summary>
        /// Initializes the game configuration file.
        /// </summary>
        public GameConfiguration()
        {
            if (!File.Exists(ConfigReader.ConfigFilePath))
            {
                throw new FileNotFoundException("Game configuration file not found.");
            }
            List<string> configuration = File.ReadAllLines(ConfigReader.ConfigFilePath).ToList();

            if (configuration.Count < 5)
            {
                throw new FormatException("GameConfiguration file is not well-formatted.");
            }

            this.BoardConfiguration = new BoardConfiguration(configuration[0]);
            this.MinesConfiguration = new MinesConfiguration(configuration[1]);
            this.ExitConfiguration = new ExitConfiguration(configuration[2]);
            this.StartConfiguration = new StartConfiguration(configuration[3]);
            this.MoveConfiguration = new MoveConfiguration(configuration.Skip(4));

            this.IsConfigured = true;
        }
    }
}
