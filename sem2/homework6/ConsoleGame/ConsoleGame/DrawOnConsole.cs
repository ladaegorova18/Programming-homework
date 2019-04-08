using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    /// <summary>
    /// Draws game process on console
    /// </summary>
    public class DrawOnConsole : IDrawable
    {
        /// <summary>
        /// Draws point where on the place gamer leaves and gamer symbol @
        /// </summary>
        /// <param name="coords"> Gamer coords </param>
        /// <param name="oldCoords"> Gamer's old coords </param>
        public void Draw((int, int) coords, (int, int) oldCoords)
        {
            WritePoint(oldCoords);
            DrawGamer(coords);
        }

        /// <summary>
        /// Draws gamer @
        /// </summary>
        /// <param name="coords"> Gamer coords </param>
        public void DrawGamer((int, int) coords)
        {
            Console.SetCursorPosition(coords.Item1, coords.Item2);
            Console.Write('@');
            --Console.CursorLeft;
        }

        private void WritePoint((int, int) oldCoords)
        {
            Console.SetCursorPosition(oldCoords.Item1, oldCoords.Item2);
            Console.Write('.');
            --Console.CursorLeft;
        }
    }
}
