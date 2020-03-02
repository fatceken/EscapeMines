using EscapeMines.Business.Core.Configuration;
using EscapeMines.Business.Core.Configuration.Interfaces;
using EscapeMines.Business.Enums;
using EscapeMines.Business.Interfaces;
using EscapeMines.Business.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeMines.Test
{
    [TestClass]
    public class GameTest
    {
        [TestMethod]
        public void Run()
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

            Assert.AreEqual(gameResult.ResultList[0], Status.StillInDanger);
            Assert.AreEqual(gameResult.ResultList[1], Status.MineHit);
            Assert.AreEqual(gameResult.ResultList[2], Status.Success);
            Assert.AreEqual(gameResult.ResultList[3], Status.OutOfBoard);
        }
    }
}
