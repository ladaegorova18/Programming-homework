using System.IO;
using System;
using System.Collections.Generic;

namespace ConsoleGame
{
    /// <summary>
    /// Main program reads map from file and starts the game
    /// </summary>
    public class Program
    {
        private static DrawOnConsole drawOnConsole = new DrawOnConsole();

        private static void Main(string[] args)
        {
            var eventLoop = new EventLoop();
            var map = new List<string>();
            var path = "map.txt";
            if (!ReadFromFile(map, path))
            {
                return;
            }
            var gamerCoords = DrawMap(map);
            var game = new Game(map, gamerCoords, drawOnConsole);
            drawOnConsole.DrawGamer(gamerCoords);
            AddHandlers(eventLoop, game);
            eventLoop.Run(); 
        }

        private static void AddHandlers(EventLoop eventLoop, Game game)
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
                    }
                    return true; // на какую позицию можем двигаться
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Файл не найден!");
                return false;
            }
        }

        private static (int, int) DrawMap(List<string> map)
        {
            foreach (var line in map)
            {
                Console.WriteLine(line);
            }
            return SettleGamer(map);
        }

        /// <summary>
        /// Draws game character on the map
        /// </summary>
        /// <param name="map"> string list to check where are the walls </param>
        public static (int, int) SettleGamer(List<string> map)
        {
            for (int line = 0; line < map.Count; ++line)
            {
                for (var i = 0; i < map[line].Length; ++i)
                {
                    if (map[line][i] != '#')
                    {
                        return (i, line);
                    }
                }
            }
            throw new ArgumentException("На карте нет свободного пространства!");
        }
    }
}
