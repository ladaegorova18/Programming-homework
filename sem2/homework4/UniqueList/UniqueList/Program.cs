using System;

namespace Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            var menu = new Menu();
            var list = MenuForList();
            menu.WorkWithMenu(list);
        }

        private static List MenuForList()
        {
            Console.WriteLine("Нажмите 1, чтобы создать список с неповторяющимися элементами;");
            Console.WriteLine("Нажмите любую другую клавишу, чтобы создать обычный список;");
            var key = Console.ReadLine();
            if (key == "1") return new UniqueList();
            return new List();
        }
    }
}
