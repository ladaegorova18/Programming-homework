using System;
using System.Collections.Generic;

namespace ConsoleGame
{
    /// <summary>
    /// Class for base actions when gamer presses up, down, left or right key on the keyboard
    /// </summary>
    public class Game
    {
        private List<string> map;
        private (int, int) coords;
        private (int, int) oldCoords;
        private IDrawable drawable;
        public (int, int) Coords
        {
            get => coords;
        }

        public Game(List<string> map, (int, int) gamerCoords, IDrawable drawable)
        {
            this.map = map;
            this.coords = gamerCoords;
            this.drawable = drawable;
        }

        private bool CheckIfNoWalls(int left, int top) => (map[top][left] != '#');

        private bool CheckIfInBounds(int left, int top) => (left > -1) && (top > -1) && (top < map.Count) && (left < map[top].Length);

        private bool IfCanMove(int left, int top) => CheckIfInBounds(left, top) && CheckIfNoWalls(left, top);


        /// <summary>
        /// Checks if there are not a wall in left from hero and moves him
        /// </summary>
        /// <param name="sender"> empty object </param>
        /// <param name="args"> empty parameters or event </param>
        public void OnLeft(object sender, EventArgs args)
        {
            oldCoords = coords;
            if (IfCanMove(coords.Item1 - 1, coords.Item2))
            {
                --coords.Item1;
            }
            drawable.Draw(coords, oldCoords);
        }

        /// <summary>
        /// Checks if there are not a wall in right from hero and moves him
        /// </summary>
        /// <param name="sender"> empty object </param>
        /// <param name="args"> empty parameters or event </param>
        public void OnRight(object sender, EventArgs args)
        {
            oldCoords = coords;
            if (IfCanMove(coords.Item1 + 1, coords.Item2))
            {
                ++coords.Item1;
            }
            drawable.Draw(coords, oldCoords);
        }

        /// <summary>
        /// Checks if there are not a wall below hero and moves him
        /// </summary>
        /// <param name="sender"> empty object </param>
        /// <param name="args"> empty parameters or event </param>
        public void OnUp(object sender, EventArgs args)
        {
            oldCoords = coords;
            if (IfCanMove(coords.Item1, coords.Item2 - 1))
            {
                --coords.Item2;
            }
            drawable.Draw(coords, oldCoords);
        }

        /// <summary>
        /// Checks if there are not a wall under hero and moves him
        /// </summary>
        /// <param name="sender"> empty object </param>
        /// <param name="args"> empty parameters or event </param>
        public void OnDown(object sender, EventArgs args)
        {
            oldCoords = coords;
            if (IfCanMove(coords.Item1, coords.Item2 + 1))
            {
                ++coords.Item2;
            }
            drawable.Draw(coords, oldCoords);
        }
    }
}
