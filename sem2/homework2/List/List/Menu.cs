using System;

namespace List
{
    class Menu
    {
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

        private void ReadPos(out int position)
        {
            var input = Console.ReadLine();
            position = int.Parse(input);
        }

        private void ReadPosAndValue(out int position, out int value)
        {
            var input = Console.ReadLine();
            var stringInput = input.Split();
            position = int.Parse(stringInput[0]); 
            value = int.Parse(stringInput[1]);
        }

        private void WriteError()
        {
            Console.WriteLine("Неверная позиция!");
        }

        private void WriteEmpty()
        {
            Console.WriteLine("Список пуст:(");
        }

        internal void WorkWithMenu(OneLinkedList list)
        {
            MainText();
            char key = Convert.ToChar(Console.ReadLine());
            while(key != '0')
            {
                WorkWithKey(key, list);
                MainText();
                key = Convert.ToChar(Console.ReadLine());
            }
            Console.WriteLine("До свидания!");
            list.DeleteList();
        }

        internal void WorkWithKey(char key, OneLinkedList list)
        {
            switch (key)
            {
                case '1':
                    {
                        Console.WriteLine("Введите позицию и значение для добавления элемента:");
                        ReadPosAndValue(out int position, out int value);
                        if (!list.Add(value, position))
                        {
                            WriteError();
                        }
                        break;
                    }
                case '2':
                    {
                        Console.WriteLine("Введите позицию для удаления элемента:");
                        ReadPos(out int position);
                        if (!list.Remove(position))
                        {
                            if (list.isEmpty())
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
                case '3':
                    {
                        if (list.isEmpty())
                        {
                            WriteEmpty();
                        }
                        else
                        {
                            Console.WriteLine("В списке что-то есть:)");
                        }
                        break;
                    }
                case '4':
                    {
                        Console.WriteLine($"В списке {list.Count()} элементов");
                        break;
                    }
                case '5':
                    {
                        Console.WriteLine("Введите позицию:");
                        ReadPos(out int position);
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
                case '6':
                    {
                        Console.WriteLine("Введите позицию и значение для изменения элемента:");
                        ReadPosAndValue(out int position, out int value);
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
