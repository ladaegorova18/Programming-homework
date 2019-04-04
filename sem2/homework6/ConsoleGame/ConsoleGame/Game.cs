using System;
using System.Collections.Generic;

namespace ConsoleGame
{
    /// <summary>
    /// Class for base actions when gamer presses up, down, left or right on the keyboard
    /// </summary>
    public class Game
    {
        private List<string> map;

        public Game(List<string> map)
        {
            this.map = map;
        }

        private bool CheckIfNoWalls(int left, int top) => (map[top][left] != '#');

        private bool CheckIfInBounds(int left, int top) => (left > -1) && (top > -1) && (top < map.Count) && (left < map[top].Length);

        private bool IfCanMove(int left, int top) => CheckIfInBounds(left, top) && CheckIfNoWalls(left, top);

        private void WritePoint()
        {
            Console.Write('.');
            --Console.CursorLeft;
        }

        /// <summary>
        /// Checks if there are not a wall in left from hero and moves him
        /// </summary>
        /// <param name="sender"> empty object </param>
        /// <param name="args"> empty parameters or event </param>
        public void OnLeft(object sender, EventArgs args)
        {
            if (IfCanMove(Console.CursorLeft - 1, Console.CursorTop))
            {
                WritePoint();
                --Console.CursorLeft;
            }
        }

        /// <summary>
        /// Checks if there are not a wall in right from hero and moves him
        /// </summary>
        /// <param name="sender"> empty object </param>
        /// <param name="args"> empty parameters or event </param>
        public void OnRight(object sender, EventArgs args)
        {
            if (IfCanMove(Console.CursorLeft + 1, Console.CursorTop))
            {
                WritePoint();
                ++Console.CursorLeft;
            }
        }

        /// <summary>
        /// Checks if there are not a wall below hero and moves him
        /// </summary>
        /// <param name="sender"> empty object </param>
        /// <param name="args"> empty parameters or event </param>
        public void OnUp(object sender, EventArgs args)
        {
            if (IfCanMove(Console.CursorLeft, Console.CursorTop - 1))
            {
                WritePoint();
                --Console.CursorTop;
            }
        }

        /// <summary>
        /// Checks if there are not a wall under hero and moves him
        /// </summary>
        /// <param name="sender"> empty object </param>
        /// <param name="args"> empty parameters or event </param>
        public void OnDown(object sender, EventArgs args)
        {
            if (IfCanMove(Console.CursorLeft, Console.CursorTop + 1))
            {
                WritePoint();
                ++Console.CursorTop;
            }
        }
    }
}
