using EscapeMines.Business.Core.Factory.Move;
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
    public class MoveTest
    {
        [TestMethod]
        public void MoveForwardTest()
        {
            IPosition current = new Position(new Coordinate(1, 1), Business.Enums.Direction.North);
            IPosition expected = new Position(new Coordinate(1, 2), Business.Enums.Direction.North);

            IMove forwardMove = new ForwardMove();
            IPosition output = forwardMove.Move(current);

            Assert.AreEqual(expected.Coordinate.X, output.Coordinate.X);
            Assert.AreEqual(expected.Coordinate.Y, output.Coordinate.Y);
            Assert.AreEqual(expected.Direction, output.Direction);
        }

        [TestMethod]
        public void MoveLeftTest()
        {
            IPosition current = new Position(new Coordinate(1, 1), Business.Enums.Direction.North);
            IPosition expected = new Position(new Coordinate(1, 1), Business.Enums.Direction.West);

            IMove leftMove = new LeftMove();
            IPosition output = leftMove.Move(current);

            Assert.AreEqual(expected.Coordinate.X, output.Coordinate.X);
            Assert.AreEqual(expected.Coordinate.Y, output.Coordinate.Y);
            Assert.AreEqual(expected.Direction, output.Direction);
        }

        [TestMethod]
        public void MoveRightTest()
        {
            IPosition current = new Position(new Coordinate(1, 1), Business.Enums.Direction.North);
            IPosition expected = new Position(new Coordinate(1, 1), Business.Enums.Direction.East);

            IMove rightMove = new RightMove();
            IPosition output = rightMove.Move(current);

            Assert.AreEqual(expected.Coordinate.X, output.Coordinate.X);
            Assert.AreEqual(expected.Coordinate.Y, output.Coordinate.Y);
            Assert.AreEqual(expected.Direction, output.Direction);
        }

        [TestMethod]
        public void NullMoveTest()
        {
            IPosition current = new Position(new Coordinate(1, 1), Business.Enums.Direction.North);
            IPosition expected = new Position(new Coordinate(1, 1), Business.Enums.Direction.North);

            IMove nullMove = new NullMove();
            IPosition output = nullMove.Move(current);

            Assert.AreEqual(expected.Coordinate.X, output.Coordinate.X);
            Assert.AreEqual(expected.Coordinate.Y, output.Coordinate.Y);
            Assert.AreEqual(expected.Direction, output.Direction);
        }
    }
}
