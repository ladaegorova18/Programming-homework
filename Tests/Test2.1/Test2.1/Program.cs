using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test2
{
    /// <summary>
    /// main program
    /// </summary>
    public class Program
    {
        /// <summary>
        /// reads file and prints sorted set
        /// </summary>
        public static void Main(string[] args)
        {
            try
            {
                using var stream = new StreamReader("file.txt");
                var comparator = new ListComparator<string>();
                var set = new SortedSet<string>(comparator);
                //ReadingFile(stream, set);
                set.Print();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Файл не найден!");
                return;
            }
        }

        private static void ReadingFile(StreamReader stream, SortedSet<List<string>> set)
        {
            while (stream.Peek() >= 0)
            {
                var str = stream.ReadLine();
                var list = new List<string>();
                string[] words = str.Split();
                foreach (string word in words)
                {
                    list.Add(word);
                }
                //set.Add(list);
            }
        }
    }
}
}
