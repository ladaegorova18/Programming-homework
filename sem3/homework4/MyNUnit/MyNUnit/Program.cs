using System.IO;

namespace MyNUnit
{
    /// <summary>
    /// main program
    /// </summary>
    public class Program
    {
        private static readonly string path = Directory.GetCurrentDirectory();

        private static void Main(string[] args)
        {
            TestingClass.Process(path + "/SuccessfulTesting");
            TestingClass.PrintResult();
        }
    }
}
