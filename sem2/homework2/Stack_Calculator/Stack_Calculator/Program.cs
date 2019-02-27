using System;

namespace Stack_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите выражение в постфиксной форме:");
            var input = Console.ReadLine();
            Console.WriteLine("Нажмите 1, если хотите использовать калькулятор на массивах;");
            Console.WriteLine("Нажмите любую другую клавишу для вызова калькулятора на списке;");
            char key = Char.Parse(Console.ReadLine());
            var calculator = new Calculator(key);
            int result = 0;
            if (key == 1)
            {
                var stack = new StackList();
                result = calculator.Count(input, stack);
            }
            else
            {
                var stack = new StackArray();
                result = calculator.Count(input, stack);
            }
            Console.WriteLine("Результат вычисления: " + result);
        }
    }
}
