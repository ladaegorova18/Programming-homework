using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test2.Tests
{
    [TestClass]
    public class XandOTests
    {
        [TestMethod]
        public void XWinTest()
        {
            var game = new XandOs();
            game.Values[0, 0] = "X";
            game.Values[0, 1] = "X";
            game.Values[0, 2] = "X";
            Assert.IsTrue(game.CheckWin("X"));
        }

        [TestMethod]
        public void OWinTest()
        {
            var game = new XandOs();
            game.Values[0, 0] = "O";
            game.Values[0, 1] = "O";
            game.Values[0, 2] = "O";
            Assert.IsTrue(game.CheckWin("O"));
        }
    }
}
