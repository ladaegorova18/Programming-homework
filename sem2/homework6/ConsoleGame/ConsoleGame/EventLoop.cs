using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    public class EventLoop
    {
        public delegate void EventHandler<TEventArgs>(object sender, TEventArgs e);
        public event EventHandler<EventArgs> LeftHandler = (sender, args) => { };
        public event EventHandler<EventArgs> RightHandler = (sender, args) => { };
        public event EventHandler<EventArgs> UpHandler = (sender, args) => { };
        public event EventHandler<EventArgs> DownHandler = (sender, args) => { };

        public void Run()
        {
            Console.SetCursorPosition();
            while (true)
            {
                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.LeftArrow:
                        {
                            LeftHandler(this, EventArgs.Empty);
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        {
                            RightHandler(this, EventArgs.Empty);
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        {
                            UpHandler(this, EventArgs.Empty);
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        {
                            DownHandler(this, EventArgs.Empty);
                        }
                        break;
                }
            }
        }
    }
}
