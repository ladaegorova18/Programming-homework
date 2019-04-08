using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    /// <summary>
    /// To draw on console in main program and not to draw while unit-testing
    /// </summary>
    public interface IDrawable
    {
        void Draw((int, int) coords, (int, int) oldCoords);

        void DrawGamer((int, int) gamerCoords);
    }
}
