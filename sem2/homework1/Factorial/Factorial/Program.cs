using System;

namespace Factorial
{
    class Program
    {
        private static int FactorialCount(int n) => n <= 1 ? 1 : n * FactorialCount(n - 1);

        static void Main(string[] args)
        {
            Console.WriteLine("Введите число:");
            var inputString = Console.ReadLine();
            int number = int.Parse(inputString);
            if (number > -1)
            {
                Console.WriteLine($"Результат: {FactorialCount(number)}");
            }
            else
            {
                Console.WriteLine("Число должно быть неотрицательным");
            }
        }
    }
}
