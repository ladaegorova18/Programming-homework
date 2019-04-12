using System;

namespace ConsoleGame
{
    /// <summary>
    /// Runs the game
    /// </summary>
    public class EventLoop
    {
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
                var coords = (Console.CursorLeft, Console.CursorTop);
                var key = Console.ReadKey();
                if (IsKeyArrow(key.Key))
                {
                    --Console.CursorLeft;
                    SwitchKey(key.Key);
                }
                else
                {
                    Console.SetCursorPosition(coords.CursorLeft, coords.CursorTop);
                }
            }
        }

        public void SwitchKey(ConsoleKey key)
        {
            switch (key)
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
                default:
                    {
                        break;
                    }
            }
        }

        private bool IsKeyArrow(ConsoleKey key) => key == ConsoleKey.LeftArrow || key == ConsoleKey.RightArrow
            || key == ConsoleKey.UpArrow || key == ConsoleKey.DownArrow;
    }
}
