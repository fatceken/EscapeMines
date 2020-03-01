using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeMines.Business.Utils
{
    /// <summary>
    /// Exposes hard-code values for environment
    /// </summary>
    public class Constants
    {
        /// <summary>
        /// Represents single space character
        /// </summary>
        public const Char Space = ' ';

        /// <summary>
        /// Represents single comma character
        /// </summary>
        public const Char Comma = ',';

        /// <summary>
        /// Represents the app.config key of game config
        /// </summary>
        public const String ConfigFilePathAppKey = "ConfigFilePath";
    }
}
