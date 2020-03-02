using EscapeMines.Business.Core.Configuration;
using EscapeMines.Business.Core.Configuration.Interfaces;
using EscapeMines.Business.Enums;
using EscapeMines.Business.Interfaces;
using EscapeMines.Business.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeMines.Test
{
    [TestClass]
    public class PerformanceTest
    {
        [TestMethod]
        public void PerformanceTest1()
        {
            //paste TestData_Performance.txt contents to config.txt before running this test

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

            gameResult.ResultList.ForEach(result =>
            {
                Assert.AreEqual(Status.StillInDanger, result);
            });
        }
    }
}
