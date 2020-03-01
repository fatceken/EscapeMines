using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeMines.Business.Utils
{
    /// <summary>
    /// Helper class for reading application values from app.config
    /// </summary>
    public class ConfigReader
    {
        /// <summary>
        /// Gets the configuration file path
        /// </summary>
        public static string ConfigFilePath
        {
            get
            {
                return ConfigurationManager.AppSettings[Constants.ConfigFilePathAppKey];
            }
        }
    }
}
