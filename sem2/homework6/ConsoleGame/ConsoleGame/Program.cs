using System.IO;
using System;
using System.Collections.Generic;

namespace ConsoleGame
{
    public class Program
    {
        static void Main(string[] args)
        {
            var eventLoop = new EventLoop();
            var map = new List<string>();
            var path = "map.txt";
            if (!ReadFromFile(map, path))
            {
                return;
            }
            var game = new Game(map);

            AddHandlers(eventLoop, game);

            eventLoop.Run(); 
        }

        public static void AddHandlers(EventLoop eventLoop, Game game)
        {
            eventLoop.LeftHandler += game.OnLeft;
            eventLoop.RightHandler += game.OnRight;
            eventLoop.UpHandler += game.OnUp;
            eventLoop.DownHandler += game.OnDown;
        }

        /// <summary>
        /// Reads map from file and adds lines to list 'map'
        /// </summary>
        /// <param name="map"> Contains lines from file </param>
        /// <param name="path"> File to read </param>
        /// <returns> If work with file was successful </returns>
        public static bool ReadFromFile(List<string> map, string path)
        {
            try
            {
                using (var stream = new StreamReader(path))
                {
                    while (stream.Peek() > 0)
                    {
                        var str = stream.ReadLine();
                        map.Add(str); // записываем в массив строки файла для проверки,
                        Console.WriteLine(str); // на какую позицию можем двигаться
                    }
                    SettleGamer(map);
                    return true;
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Файл не найден!");
                return false;
            }
        }

        /// <summary>
        /// Draws game character on the map
        /// </summary>
        /// <param name="map"> string list to check where are the walls </param>
        private static void SettleGamer(List<string> map)
        {
            for (int line = 0; line < map.Count; ++line)
            {
                for (var i = 0; i < map[line].Length; ++i)
                {
                    if (map[line][i] != '#')
                    {
                        Console.SetCursorPosition(i, line);
                        Console.Write('@');
                        --Console.CursorLeft;
                        return;
                    }
                }
            }
        }
    }
}
