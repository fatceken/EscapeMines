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
                Console.WriteLine(GetFinishInfo(game));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                logger.Error(ex);
            }

            Console.ReadLine();
        }

        private static string GetFinishInfo(IGame game)
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < game.ResultList.Count; i++)
            {
                stringBuilder.AppendLine(string.Format("Sequence {0} = {1} ", i, game.ResultList[i].ToString()));

                stringBuilder.Append("Visited Positions : ");
                game.VisitedPositions[i].ForEach(item =>
                {
                    stringBuilder.Append(string.Format("[ {0} {1} {2} ]  ", item.Coordinate.X, item.Coordinate.Y, item.Direction.ToString()));
                });

                stringBuilder.AppendLine("\n");
            }

            return stringBuilder.ToString();
        }
    }
}
