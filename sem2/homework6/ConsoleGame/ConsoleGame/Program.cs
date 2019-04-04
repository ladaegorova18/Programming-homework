using System.IO;

namespace ConsoleGame
{
    class Program
    {
        static void Main(string[] args)
        {
            //ReadFromFile();
            var eventLoop = new EventLoop();
            var game = new Game();

            eventLoop.LeftHandler += game.OnLeft;
            eventLoop.RightHandler += game.OnRight;
            eventLoop.UpHandler += game.OnUp;
            eventLoop.DownHandler += game.OnDown;

            eventLoop.Run();
            int function (int value, Func<int, int> func)
            {
                return func(value);
            }
        }

        static void ReadFromFile()
        {
            using (var stream = new StreamReader("map.txt"))
            while (stream.Peek() > 0)
            {

            }
        }
    }
}
