using System;

namespace Lists
{
    class Menu
    {
        public void WorkWithMenu(List list)
        {
            MainText();
            string key = Console.ReadLine();
            while (key != "0")
            {
                WorkWithKey(key, list);
                MainText();
                key = Console.ReadLine();
            }
            Console.WriteLine("До свидания!");
            list.Clear();
        }

        private void MainText()
        {
            Console.WriteLine("Это меню связного списка. Нажмите:");
            Console.WriteLine("1, чтобы добавить элемент в список;");
            Console.WriteLine("2, чтобы удалить элемент из списка;");
            Console.WriteLine("3, чтобы проверить список на пустоту;");
            Console.WriteLine("4, чтобы узнать число элементов списка;");
            Console.WriteLine("0, чтобы выйти.");
        }

        private string ReadValue()
        {
            var value = Console.ReadLine();
            return value;
        }

        private void WriteEmpty()
        {
            Console.WriteLine("Список пуст:(");
        }

        public void WorkWithKey(string key, List list)
         {
            switch (key)
            {
                case "1":
                    {
                        Console.WriteLine("Введите значение для добавления:");
                        var value = ReadValue();
                        list.Add(value);
                        break;
                    }
                case "2":
                    {
                        Console.WriteLine("Введите значение для удаления:");
                        string position = ReadValue();
                        if (!list.Remove(position))
                        {
                            if (list.IsEmpty())
                            {
                                WriteEmpty();
                            }
                        }
                        break;
                    }
                case "3":
                    {
                        if (list.IsEmpty())
                        {
                            WriteEmpty();
                        }
                        else
                        {
                            Console.WriteLine("В списке что-то есть:)");
                        }
                        break;
                    }
                case "4":
                    {
                        Console.WriteLine($"В списке {list.Count()} элементов)");
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Что-то введено не так:)");
                        break;
                    }
            }
        }
    }
}
