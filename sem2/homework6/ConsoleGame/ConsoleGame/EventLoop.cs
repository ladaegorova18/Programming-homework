using System;

namespace ConsoleGame
{
    /// <summary>
    /// Runs the game
    /// </summary>
    public class EventLoop
    {
        public delegate void EventHandler<TEventArgs>(object sender, TEventArgs e);
        public event EventHandler<EventArgs> LeftHandler = (sender, args) => { };
        public event EventHandler<EventArgs> RightHandler = (sender, args) => { };
        public event EventHandler<EventArgs> UpHandler = (sender, args) => { };
        public event EventHandler<EventArgs> DownHandler = (sender, args) => { };

        /// <summary>
        /// In infinite loop reads key from keyboard and does an action from game class
        /// </summary>
        public void Run()
        {
            while (true)
            {
                var key = Console.ReadKey();
                --Console.CursorLeft;
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
                DrawGamer();
            }
        }

        private void DrawGamer()
        {
            Console.Write('@');
            --Console.CursorLeft;
        }
    }
}
