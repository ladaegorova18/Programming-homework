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
            try
            {
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
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Некорректный ввод!");
                return;
            }
            Console.WriteLine("Результат вычисления: " + result);
        }
    }
}
