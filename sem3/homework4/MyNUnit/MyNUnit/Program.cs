using System.IO;

namespace MyNUnit
{
    public class Program
    {
        private static readonly string path = Directory.GetCurrentDirectory();

        private static void Main(string[] args)
        {
            var tester = new TestingClass(path + "/SuccessfulTesting");
            tester.Process();
            tester.PrintResult();
        }
    }
}
