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
            Console.WriteLine("Результат вычисления: " + calculator.Count(input));
        }
    }
}
