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
            IGame game = new Game();
            game.Run();
            Assert.AreEqual(game.ResultList[0], Status.StillInDanger);
            Assert.AreEqual(game.ResultList[1], Status.MineHit);
            Assert.AreEqual(game.ResultList[2], Status.Success);
            Assert.AreEqual(game.ResultList[3], Status.OutOfBoard);
        }
    }
}
