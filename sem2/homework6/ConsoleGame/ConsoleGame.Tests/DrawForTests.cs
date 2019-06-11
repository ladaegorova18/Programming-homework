using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame.Tests
{
    /// <summary>
    /// Empty functions for unit-testing
    /// </summary>
    public class DrawForTests : IDrawable
    {
        public void Draw((int, int) coords, (int, int) oldCoords)
        {
        }

        public void DrawGamer((int, int) coords)
        {
        }
    }
}
