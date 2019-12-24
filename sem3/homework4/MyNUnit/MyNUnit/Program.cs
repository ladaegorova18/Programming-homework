using System;

namespace MyNUnit
{
    public class Program
    {
        private static string path = "../Tests";

        private static void Main(string[] args)
        {
            var tester = new TestingClass(path + "/SuccessfulTesting/SuccessfulTesting");
            tester.Process();
            tester.PrintResult();
        }
    }
}
