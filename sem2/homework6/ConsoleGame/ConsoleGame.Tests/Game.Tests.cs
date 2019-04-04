using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleGame.Tests
{
    [TestClass]
    public class GameTests
    {
        private List<string> map;
        Game game;
        object sender;
        EventArgs args;
        (int, int) coords;

        [TestInitialize]
        public void Initialize()
        {
            map = new List<string>();
            Program.ReadFromFile(map, "test.txt");
            game = new Game(map);
        }
        /*
         *##########
          #.........
          .........#
          */
        [TestMethod]
        public void MoveUpTest()
        {
            game.OnUp(sender, args);
            coords = GetCoords();
            Assert.AreEqual((1, 1), coords);
        }

        [TestMethod]
        public void MoveDownTest()
        {
            game.OnDown(sender, args);
            coords = GetCoords();
            Assert.AreEqual((1, 2), coords);
        }


        [TestMethod]
        public void MoveLeftTest()
        {
            game.OnLeft(sender, args);
            coords = GetCoords();
            Assert.AreEqual((1, 1), coords);
        }

        [TestMethod]
        public void MoveRightTest()
        {
            game.OnRight(sender, args);
            coords = GetCoords();
            Assert.AreEqual((2, 1), coords);
        }

        [TestMethod]
        public void DoubleMoveDownTest()
        {
            game.OnDown(sender, args);
            game.OnDown(sender, args);
            coords = GetCoords();
            Assert.AreEqual((1, 2), coords);
        }

        [TestMethod]
        public void DoubleMoveRightTest()
        {
            game.OnRight(sender, args);
            game.OnRight(sender, args);
            coords = GetCoords();
            Assert.AreEqual((3, 1), coords);
        }

        private (int, int) GetCoords() => (Console.CursorLeft, Console.CursorTop);

    }
}
