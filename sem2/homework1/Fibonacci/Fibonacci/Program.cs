using System;

namespace Fibonacci
{
    class Program
    {
        private static int FibonacciCount(int n)
        {
            if (n <= 2)
            {
                return 1;
            }

            return FibonacciCount(n - 1) + FibonacciCount(n - 2);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите номер числа Фибоначчи:");
            var input = Console.ReadLine();
            int number = int.Parse(input);
            if (number > 0)
            {
                Console.WriteLine("{0} число Фибоначчи: {1}", input, FibonacciCount(number));
            }
            else
            {
                Console.WriteLine("Номер должен быть положительным!");
            }
        }
    }
}
