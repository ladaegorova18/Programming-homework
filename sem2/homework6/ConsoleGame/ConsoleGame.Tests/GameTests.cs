using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleGame.Tests
{
    [TestClass]
    public class GameTests
    {
        private List<string> map;
        private Game game;
        private (int, int) coords;
        private EventLoop eventLoop;
        private ConsoleKey key;

        [TestInitialize]
        public void Initialize()
        {
            map = new List<string>();
            Program.ReadFromFile(map, "test.txt");
            var gamerCoords = Program.SettleGamer(map);
            game = new Game(map, gamerCoords, new DrawForTests());
            eventLoop = new EventLoop();
            eventLoop.LeftHandler += game.OnLeft;
            eventLoop.RightHandler += game.OnRight;
            eventLoop.UpHandler += game.OnUp;
            eventLoop.DownHandler += game.OnDown;
        }
        /* ##########
           #.........
           .........# 
           test map 
           */

        [TestMethod]
        public void StartPosition()
        {
            coords = game.Coords;
            Assert.AreEqual((1, 1), coords);
        }

        [TestMethod]
        public void MoveUpTest()
        {
            eventLoop.SwitchKey(ConsoleKey.UpArrow);
            coords = game.Coords;
            Assert.AreEqual((1, 1), coords);
        }

        [TestMethod]
        public void MoveDownTest()
        {
            eventLoop.SwitchKey(ConsoleKey.DownArrow);
            coords = game.Coords;
            Assert.AreEqual((1, 2), coords);
        }


        [TestMethod]
        public void MoveLeftTest()
        {
            eventLoop.SwitchKey(ConsoleKey.LeftArrow);
            coords = game.Coords;
            Assert.AreEqual((1, 1), coords);
        }

        [TestMethod]
        public void MoveRightTest()
        {
            eventLoop.SwitchKey(ConsoleKey.RightArrow);
            coords = game.Coords;
            Assert.AreEqual((2, 1), coords);
        }

        [TestMethod]
        public void DoubleMoveDownTest()
        {
            key = ConsoleKey.DownArrow;
            eventLoop.SwitchKey(key);
            eventLoop.SwitchKey(key);
            coords = game.Coords;
            Assert.AreEqual((1, 2), coords);
        }

        [TestMethod]
        public void DoubleMoveRightTest()
        {
            key = ConsoleKey.RightArrow;
            eventLoop.SwitchKey(key);
            eventLoop.SwitchKey(key);
            coords = game.Coords;
            Assert.AreEqual((3, 1), coords);
        }

        [TestMethod]
        public void ToTheUpEdgeTest()
        {
            for (var i = 0; i < 10; ++i)
            {
                key = ConsoleKey.UpArrow;
                eventLoop.SwitchKey(key);
            }
            coords = game.Coords;
            Assert.AreEqual((1, 1), coords);
        }

        [TestMethod]
        public void TryToGoOutOfBordersTest()
        {
            for (var i = 0; i < 10; ++i)
            {
                key = ConsoleKey.RightArrow;
                eventLoop.SwitchKey(key);
            }
            coords = game.Coords;
            Assert.AreEqual((9, 1), coords);
        }

        [TestMethod]
        public void ThreeRightAndOneDownTest()
        {
            for (var i = 0; i < 3; ++i)
            {
                key = ConsoleKey.RightArrow;
                eventLoop.SwitchKey(key);
            }
            key = ConsoleKey.DownArrow;
            eventLoop.SwitchKey(key);
            coords = game.Coords;
            Assert.AreEqual((4, 2), coords);
        }

        [TestMethod]
        public void SquareTest()
        {
            var originCoords = game.Coords;
            key = ConsoleKey.RightArrow;
            eventLoop.SwitchKey(key);
            key = ConsoleKey.DownArrow;
            eventLoop.SwitchKey(key);
            key = ConsoleKey.LeftArrow;
            eventLoop.SwitchKey(key);
            key = ConsoleKey.UpArrow;
            eventLoop.SwitchKey(key);
            var coords = game.Coords;
            Assert.AreEqual(originCoords, coords);
        }
    } 
}
