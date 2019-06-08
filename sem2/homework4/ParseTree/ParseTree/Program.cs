using System;

namespace ParseTree
{
    /// <summary>
    /// main program
    /// </summary>
    public class Program
    {
        /// <summary>
        /// main method
        /// </summary>
        public static void Main(string[] args)
        {
            var tree = new Tree();
            var filePath = @"text.txt";
            tree.ReadFromFile(filePath);
            try
            {
                Console.WriteLine("Результат равен: " + tree.Count());
                tree.Print();

            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
