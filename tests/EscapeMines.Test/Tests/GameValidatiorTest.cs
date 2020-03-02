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
    public class GameValidatiorTest
    {
        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void StartIsOnMine()
        {
            IBoardConfiguration boardConfiguration = new BoardConfiguration("5 4");
            IExitConfiguration exitConfiguration = new ExitConfiguration("4 2");
            IMinesConfiguration minesConfiguration = new MinesConfiguration("1,1 1,3 3,3");
            IMoveConfiguration moveConfiguration = new MoveConfiguration(new List<string>() { "M R L", "L M R", "R M L" });
            IStartConfiguration startConfiguration = new StartConfiguration("1 1 N");

            IBoard board = boardConfiguration.GetBoard();
            List<ICoordinate> mines = minesConfiguration.GetMines();
            ICoordinate exit = exitConfiguration.GetExitPoint();
            IPosition start = startConfiguration.GetStartPoint();
            List<List<MoveType>> moves = moveConfiguration.GetMoves();
            ITurtle turtle = new Turtle(start);

            IGameValidator gameValidator = new GameValidator(board, mines, exit, start, moves, turtle);
            gameValidator.Validate();
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void ExitIsOnMine()
        {
            IBoardConfiguration boardConfiguration = new BoardConfiguration("5 4");
            IExitConfiguration exitConfiguration = new ExitConfiguration("4 2");
            IMinesConfiguration minesConfiguration = new MinesConfiguration("4,2 1,3 3,3");
            IMoveConfiguration moveConfiguration = new MoveConfiguration(new List<string>() { "M R L", "L M R", "R M L" });
            IStartConfiguration startConfiguration = new StartConfiguration("0 1 N");

            IBoard board = boardConfiguration.GetBoard();
            List<ICoordinate> mines = minesConfiguration.GetMines();
            ICoordinate exit = exitConfiguration.GetExitPoint();
            IPosition start = startConfiguration.GetStartPoint();
            List<List<MoveType>> moves = moveConfiguration.GetMoves();
            ITurtle turtle = new Turtle(start);

            IGameValidator gameValidator = new GameValidator(board, mines, exit, start, moves, turtle);
            gameValidator.Validate();
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void MineIsNotInBoard()
        {
            IBoardConfiguration boardConfiguration = new BoardConfiguration("5 4");
            IExitConfiguration exitConfiguration = new ExitConfiguration("4 2");
            IMinesConfiguration minesConfiguration = new MinesConfiguration("9,7 1,3 3,3");
            IMoveConfiguration moveConfiguration = new MoveConfiguration(new List<string>() { "M R L", "L M R", "R M L" });
            IStartConfiguration startConfiguration = new StartConfiguration("0 1 N");

            IBoard board = boardConfiguration.GetBoard();
            List<ICoordinate> mines = minesConfiguration.GetMines();
            ICoordinate exit = exitConfiguration.GetExitPoint();
            IPosition start = startConfiguration.GetStartPoint();
            List<List<MoveType>> moves = moveConfiguration.GetMoves();
            ITurtle turtle = new Turtle(start);

            IGameValidator gameValidator = new GameValidator(board, mines, exit, start, moves, turtle);
            gameValidator.Validate();
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void StartIsNotOnBoard()
        {
            IBoardConfiguration boardConfiguration = new BoardConfiguration("5 4");
            IExitConfiguration exitConfiguration = new ExitConfiguration("4 2");
            IMinesConfiguration minesConfiguration = new MinesConfiguration("1,1 1,3 3,3");
            IMoveConfiguration moveConfiguration = new MoveConfiguration(new List<string>() { "M R L", "L M R", "R M L" });
            IStartConfiguration startConfiguration = new StartConfiguration("6 9 N");

            IBoard board = boardConfiguration.GetBoard();
            List<ICoordinate> mines = minesConfiguration.GetMines();
            ICoordinate exit = exitConfiguration.GetExitPoint();
            IPosition start = startConfiguration.GetStartPoint();
            List<List<MoveType>> moves = moveConfiguration.GetMoves();
            ITurtle turtle = new Turtle(start);

            IGameValidator gameValidator = new GameValidator(board, mines, exit, start, moves, turtle);
            gameValidator.Validate();
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void ExitIsNotOnBoard()
        {
            IBoardConfiguration boardConfiguration = new BoardConfiguration("5 4");
            IExitConfiguration exitConfiguration = new ExitConfiguration("7 8");
            IMinesConfiguration minesConfiguration = new MinesConfiguration("1,1 1,3 3,3");
            IMoveConfiguration moveConfiguration = new MoveConfiguration(new List<string>() { "M R L", "L M R", "R M L" });
            IStartConfiguration startConfiguration = new StartConfiguration("0 1 N");

            IBoard board = boardConfiguration.GetBoard();
            List<ICoordinate> mines = minesConfiguration.GetMines();
            ICoordinate exit = exitConfiguration.GetExitPoint();
            IPosition start = startConfiguration.GetStartPoint();
            List<List<MoveType>> moves = moveConfiguration.GetMoves();
            ITurtle turtle = new Turtle(start);

            IGameValidator gameValidator = new GameValidator(board, mines, exit, start, moves, turtle);
            gameValidator.Validate();
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void StartAndExitEqual()
        {
            IBoardConfiguration boardConfiguration = new BoardConfiguration("5 4");
            IExitConfiguration exitConfiguration = new ExitConfiguration("0 1");
            IMinesConfiguration minesConfiguration = new MinesConfiguration("1,1 1,3 3,3");
            IMoveConfiguration moveConfiguration = new MoveConfiguration(new List<string>() { "M R L", "L M R", "R M L" });
            IStartConfiguration startConfiguration = new StartConfiguration("0 1 N");

            IBoard board = boardConfiguration.GetBoard();
            List<ICoordinate> mines = minesConfiguration.GetMines();
            ICoordinate exit = exitConfiguration.GetExitPoint();
            IPosition start = startConfiguration.GetStartPoint();
            List<List<MoveType>> moves = moveConfiguration.GetMoves();
            ITurtle turtle = new Turtle(start);

            IGameValidator gameValidator = new GameValidator(board, mines, exit, start, moves, turtle);
            gameValidator.Validate();
        }
    }
}
