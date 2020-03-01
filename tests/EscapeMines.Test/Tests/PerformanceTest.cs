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

            IGame game = new Game();
            game.Run();

            game.ResultList.ForEach(result =>
            {
                Assert.AreEqual(Status.StillInDanger, result);
            });
        }
    }
}
