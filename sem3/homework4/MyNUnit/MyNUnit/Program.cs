using System;

namespace MyNUnit
{
    /// <summary>
    /// main program
    /// </summary>
    public class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Enter path to directory:");
            var path = Console.ReadLine();
            TestingClass.Process("path");
            TestingClass.PrintResult();
        }
    }
}
