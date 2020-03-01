using EscapeMines.Business.Enums;
using EscapeMines.Business.Interfaces;
using EscapeMines.Business.Models;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeMines
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Log4NetInit

            log4net.Config.XmlConfigurator.Configure();
            ILog logger = log4net.LogManager.GetLogger(typeof(Program));

            #endregion

            try
            {
                IGame game = new Game();
                game.Run();
                Console.WriteLine(game.FinishInfo);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                logger.Error(ex);
            }

            Console.ReadLine();
        }
    }
}
