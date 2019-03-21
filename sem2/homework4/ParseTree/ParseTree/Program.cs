using System;

namespace ParseTree
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var tree = new Tree();
            var filePath = @"text.txt";
            tree.ReadFromFile(filePath);
            try
            {
                Console.WriteLine("Результат равен: " + tree.Count());
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
