using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    public class Game
    {
        public void OnLeft(object sender, EventArgs args)
        {
            Console.WriteLine("Going left");

        }

        public void OnRight(object sender, EventArgs args)
        {
            Console.WriteLine("Going right");
        }

        public void OnUp(object sender, EventArgs args)
        {
            Console.WriteLine("Going up");
        }

        public void OnDown(object sender, EventArgs args)
        {
            Console.WriteLine("Going down");
        }
    }
}
