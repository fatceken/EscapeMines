using EscapeMines.Business.Core.Configuration;
using EscapeMines.Business.Core.Configuration.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeMines.Test
{
    [TestClass]
    public class ConfigurationTest
    {
        [TestMethod]
        public void GameConfigrationTest()
        {
            IGameConfiguration gameConfiguration = new GameConfiguration();
            Assert.IsTrue(gameConfiguration.IsConfigured);
        }

        [TestMethod]
        public void BoardConfigrationTest()
        {
            IBoardConfiguration boardConfiguration = new BoardConfiguration("5 4");
            Assert.AreEqual(boardConfiguration.GetBoard().Max.X, 4);
            Assert.AreEqual(boardConfiguration.GetBoard().Max.Y, 3);
        }

        [TestMethod]
        public void ExitConfigrationTest()
        {
            IExitConfiguration exitConfiguration = new ExitConfiguration("4 2");
            Assert.AreEqual(exitConfiguration.GetExitPoint().X, 4);
            Assert.AreEqual(exitConfiguration.GetExitPoint().Y, 2);
        }

        [TestMethod]
        public void MinesConfigrationTest()
        {
            IMinesConfiguration minesConfiguration = new MinesConfiguration("1,1 1,3 3,3");

            Assert.AreEqual(minesConfiguration.GetMines()[0].X, 1);
            Assert.AreEqual(minesConfiguration.GetMines()[0].Y, 1);

            Assert.AreEqual(minesConfiguration.GetMines()[1].X, 1);
            Assert.AreEqual(minesConfiguration.GetMines()[1].Y, 3);

            Assert.AreEqual(minesConfiguration.GetMines()[2].X, 3);
            Assert.AreEqual(minesConfiguration.GetMines()[2].Y, 3);

        }

        [TestMethod]
        public void MoveConfigrationTest()
        {
            IMoveConfiguration moveConfiguration = new MoveConfiguration(new List<string>() { "M R L", "L M R", "R M L" });

            Assert.AreEqual(moveConfiguration.GetMoves()[0][0], Business.Enums.MoveType.Forward);
            Assert.AreEqual(moveConfiguration.GetMoves()[0][1], Business.Enums.MoveType.Right);
            Assert.AreEqual(moveConfiguration.GetMoves()[0][2], Business.Enums.MoveType.Left);

            Assert.AreEqual(moveConfiguration.GetMoves()[1][0], Business.Enums.MoveType.Left);
            Assert.AreEqual(moveConfiguration.GetMoves()[1][1], Business.Enums.MoveType.Forward);
            Assert.AreEqual(moveConfiguration.GetMoves()[1][2], Business.Enums.MoveType.Right);

            Assert.AreEqual(moveConfiguration.GetMoves()[2][0], Business.Enums.MoveType.Right);
            Assert.AreEqual(moveConfiguration.GetMoves()[2][1], Business.Enums.MoveType.Forward);
            Assert.AreEqual(moveConfiguration.GetMoves()[2][2], Business.Enums.MoveType.Left);
        }

        [TestMethod]
        public void StartConfigrationTest()
        {
            IStartConfiguration startConfiguration = new StartConfiguration("0 1 N");
            Assert.AreEqual(startConfiguration.GetStartPoint().Coordinate.X, 0);
            Assert.AreEqual(startConfiguration.GetStartPoint().Coordinate.Y, 1);
            Assert.AreEqual(startConfiguration.GetStartPoint().Direction, Business.Enums.Direction.North);
        }
    }
}
