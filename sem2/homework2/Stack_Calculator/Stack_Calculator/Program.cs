using System;

namespace StackCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите выражение в постфиксной форме:");
            var input = Console.ReadLine();
            Console.WriteLine("Нажмите 1, если хотите использовать калькулятор на массивах;");
            Console.WriteLine("Нажмите любую другую клавишу для вызова калькулятора на списке;");
            var key = Console.ReadLine();
            var calculator = new Calculator();
            int result = 0;
            if (key == "1")
            {
                var stack = new StackList();
                result = calculator.Count(input, stack);
            }
            else
            {
                var stack = new StackArray();
                result = calculator.Count(input, stack);
            }
            if (result < 0)
            {
                if (result == -1)
                {
                    Console.WriteLine("Некорректный ввод!");
                    return;
                }
                if (result == -2)
                {
                    Console.WriteLine("Отрицательный результат!");
                    return;
                }
            }

            Console.WriteLine("Результат вычисления: " + result);
        }
    }
}
