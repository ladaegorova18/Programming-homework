using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    /// <summary>
    /// To draw gamer's path on console
    /// </summary>
    public interface IDrawable
    {
        void Draw((int, int) coords, (int, int) oldCoords);

        void DrawGamer((int, int) gamerCoords);
    }
}
