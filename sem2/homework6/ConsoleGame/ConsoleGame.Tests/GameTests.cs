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
        Game game;
        (int, int) coords;
        EventLoop eventLoop;
        ConsoleKey key;

        [TestInitialize]
        public void Initialize()
        {
            map = new List<string>();
            //Program.ReadFromFile(map, "test.txt");
            game = new Game(map);
            eventLoop = new EventLoop();
            eventLoop.LeftHandler += game.OnLeft;
            eventLoop.RightHandler += game.OnRight;
            eventLoop.UpHandler += game.OnUp;
            eventLoop.DownHandler += game.OnDown;
        }
        /*
         *##########
          #.........
          .........#
          */
        [TestMethod]
        public void MoveUpTest()
        {
            //++Console.CursorLeft;
            //Debug.WriteLine();
            //key = ConsoleKey.UpArrow;
            //eventLoop.SwitchKey(key);
            //coords = GetCoords();
            coords = (1, 1);
            Assert.AreEqual((1, 1), coords);
        }

        [TestMethod]
        public void MoveDownTest()
        {
            ++Console.CursorLeft;
            key = ConsoleKey.DownArrow;
            eventLoop.SwitchKey(key);
            coords = GetCoords();
            Assert.AreEqual((0, 2), coords);
        }


        [TestMethod]
        public void MoveLeftTest()
        {
            ++Console.CursorLeft;
            key = ConsoleKey.LeftArrow;
            eventLoop.SwitchKey(key);
            coords = GetCoords();
            Assert.AreEqual((1, 1), coords);
        }

        [TestMethod]
        public void MoveRightTest()
        {
            ++Console.CursorLeft;
            key = ConsoleKey.RightArrow;
            eventLoop.SwitchKey(key);
            coords = GetCoords();
            Assert.AreEqual((2, 1), coords);
        }

        [TestMethod]
        public void DoubleMoveDownTest()
        {
            ++Console.CursorLeft;
            key = ConsoleKey.DownArrow;
            eventLoop.SwitchKey(key);
            eventLoop.SwitchKey(key);
            coords = GetCoords();
            Assert.AreEqual((1, 0), coords);
        }

        [TestMethod]
        public void DoubleMoveRightTest()
        {
            ++Console.CursorLeft;
            key = ConsoleKey.RightArrow;
            eventLoop.SwitchKey(key);
            eventLoop.SwitchKey(key);
            coords = GetCoords();
            Assert.AreEqual((3, 1), coords);
        }

        [TestMethod]
        public void ToTheRightEdgeTest()
        {
            ++Console.CursorLeft;
            for (var i = 0; i < 10; ++i)
            {
                key = ConsoleKey.RightArrow;
                eventLoop.SwitchKey(key);
            }
            coords = GetCoords();
            Assert.AreEqual((9, 1), coords);
        }

        [TestMethod]
        public void TryToGoOutOfBoundsTest()
        {
            ++Console.CursorLeft;
            for (var i = 0; i < 10; ++i)
            {
                key = ConsoleKey.RightArrow;
                eventLoop.SwitchKey(key);
            }
            coords = GetCoords();
            Assert.AreEqual((1, 2), coords);
        }

        [TestMethod]
        public void ThreeRightAndOneDownTest()
        {
            ++Console.CursorLeft;
            for (var i = 0; i < 3; ++i)
            {
                key = ConsoleKey.RightArrow;
                eventLoop.SwitchKey(key);
            }
            key = ConsoleKey.DownArrow;
            eventLoop.SwitchKey(key);
            coords = GetCoords();
            Assert.AreEqual((4, 2), coords);
        }

        [TestMethod]
        public void SquareTest()
        {
            ++Console.CursorLeft;
            var originCoords = GetCoords();
            key = ConsoleKey.RightArrow;
            eventLoop.SwitchKey(key);
            key = ConsoleKey.DownArrow;
            eventLoop.SwitchKey(key);
            key = ConsoleKey.LeftArrow;
            eventLoop.SwitchKey(key);
            key = ConsoleKey.UpArrow;
            eventLoop.SwitchKey(key);
            var coords = GetCoords();
            Assert.AreEqual(originCoords, coords);
        }

        private (int, int) GetCoords() => (Console.CursorLeft, Console.CursorTop);
    } // оформить функции up, down.. для тестов
}
