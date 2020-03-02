using EscapeMines.Business.Core.Configuration;
using EscapeMines.Business.Core.Configuration.Interfaces;
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
                IGameConfiguration configuration = new GameConfiguration();
                IBoard board = configuration.BoardConfiguration.GetBoard();
                List<ICoordinate> mines = configuration.MinesConfiguration.GetMines();
                ICoordinate exit = configuration.ExitConfiguration.GetExitPoint();
                IPosition start = configuration.StartConfiguration.GetStartPoint();
                List<List<MoveType>> moves = configuration.MoveConfiguration.GetMoves();
                ITurtle turtle = new Turtle(start);
                IGameValidator gameValidator = new GameValidator(board, mines, exit, start, moves, turtle);

                IGame game = new Game(board, mines, exit, start, moves, turtle, gameValidator);
                GameResult gameResult = game.Run();

                Console.WriteLine(GetFinishInfo(gameResult));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                logger.Error(ex);
            }

            Console.ReadLine();
        }

        private static string GetFinishInfo(GameResult gameResult)
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < gameResult.ResultList.Count; i++)
            {
                stringBuilder.AppendLine(string.Format("Sequence {0} = {1} ", i, gameResult.ResultList[i].ToString()));

                stringBuilder.Append("Visited Positions : ");
                gameResult.VisitedPositions[i].ForEach(item =>
                {
                    stringBuilder.Append(string.Format("[ {0} {1} {2} ]  ", item.Coordinate.X, item.Coordinate.Y, item.Direction.ToString()));
                });

                stringBuilder.AppendLine("\n");
            }

            return stringBuilder.ToString();
        }
    }
}
