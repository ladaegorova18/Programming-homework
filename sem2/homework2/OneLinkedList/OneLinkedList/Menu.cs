using System;

namespace List
{
    class Menu
    {
        public void WorkWithMenu(OneLinkedList list)
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
            Console.WriteLine("1, чтобы добавить элемент в список на выбранную позицию;");
            Console.WriteLine("2, чтобы удалить элемент из списка по выбранной позиции");
            Console.WriteLine("3, чтобы проверить список на пустоту;");
            Console.WriteLine("4, чтобы узнать число элементов списка;");
            Console.WriteLine("5, чтобы получить значение элемента по выбранной позиции;");
            Console.WriteLine("6, чтобы изменить значение элемента по выбранной позиции;");
            Console.WriteLine("0, чтобы выйти.");
        }

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

        private void WriteEmpty()
        {
            Console.WriteLine("Список пуст:(");
        }

        public void WorkWithKey(string key, OneLinkedList list)
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
                        Console.WriteLine($"В списке {list.Count()} элементов)");
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
