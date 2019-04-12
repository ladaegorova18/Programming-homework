using System;

namespace Lists
{
    /// <summary>
    /// User menu to add, remove or find data in list
    /// </summary>
    public class Menu
    {
        /// <summary>
        /// User function to work with menu
        /// </summary>
        /// <param name="list"> list to work with </param>
        public void WorkWithMenu(List list)
        {
            MainText(list);
            string key = Console.ReadLine();
            while (key != "0")
            {
                WorkWithKey(key, list);
                MainText(list);
                key = Console.ReadLine();
            }
            Console.WriteLine("До свидания!");
        }

        private static void MainText(List list)
        {
            if (list is UniqueList)
            {
                Console.WriteLine("Это меню списка с неповторяющимися элементами. Нажмите:");
            }
            else
            {
                Console.WriteLine("Это меню связного списка. Нажмите:");
            }
            Console.WriteLine("1, чтобы добавить элемент в список на выбранную позицию;");
            Console.WriteLine("2, чтобы удалить элемент из списка по выбранной позиции");
            Console.WriteLine("3, чтобы проверить список на пустоту;");
            Console.WriteLine("4, чтобы узнать число элементов списка;");
            Console.WriteLine("5, чтобы получить значение элемента по выбранной позиции;");
            Console.WriteLine("6, чтобы изменить значение элемента по выбранной позиции;");
            Console.WriteLine("0, чтобы выйти.");
        }

        private static void WriteEmpty()
        {
            Console.WriteLine("Список пуст:(");
        }

        /// <summary>
        /// here user chooses an option to do with list
        /// </summary>
        /// <param name="key"> key of operation </param>
        /// <param name="list"> list to work with </param>
        private int ReadPos()
        {
            var input = Console.ReadLine();
            int.TryParse(input, out int position);
            return position;
        }

        private (int position, string value) ReadPosAndValue()
        {
            var input = Console.ReadLine();
            var arrayInput = input.Split();
            int.TryParse(arrayInput[0], out int position);
            string value = arrayInput[1];
            return (position, value);
        }

        private void WriteError()
        {
            Console.WriteLine("Неверная позиция!");
        }

        public void WorkWithKey(string key, List list)
        {
            switch (key)
            {
                case "1":
                    {
                        Console.WriteLine("Введите позицию и значение для добавления элемента:");
                        (int position, string value) = ReadPosAndValue();
                        if (!list.Add(value, position))
                        {
                            WriteError();
                        }
                        break;
                    }
                case "2":
                    {
                        Console.WriteLine("Введите позицию для удаления элемента:");
                        int position = ReadPos();
                        if (!list.Remove(position))
                        {
                            if (list.IsEmpty())
                            {
                                WriteEmpty();
                            }
                            else
                            {
                                WriteError();
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
                        Console.WriteLine($"В списке {list.Size} элементов)");
                        break;
                    }
                case "5":
                    {
                        Console.WriteLine("Введите позицию:");
                        int position = ReadPos();
                        if (position < 0)
                        {
                            WriteError();
                        }
                        else
                        {
                            Console.WriteLine($"{position} элемент: {list.GetValue(position)}");
                        }
                        break;
                    }
                case "6":
                    {
                        Console.WriteLine("Введите позицию и значение для изменения элемента:");
                        (int position, string value) = ReadPosAndValue();
                        if (!list.SetValue(value, position))
                        {
                            WriteError();
                        }
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
