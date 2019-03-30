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

        private void MainText(List list)
        {
            if (list is UniqueList)
                Console.WriteLine("Это меню списка с неповторяющимися элементами. Нажмите:");
            else
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

        /// <summary>
        /// here user chooses an option to do with list
        /// </summary>
        /// <param name="key"> key of operation </param>
        /// <param name="list"> list to work with </param>
        public void WorkWithKey(string key, List list)
         {
            switch (key)
            {
                case "1":
                    {
                        Console.WriteLine("Введите значение для добавления:");
                        var value = ReadValue();
                        try
                        {
                            list.Add(value);
                        }
                        catch (AddingExistingNodeException e)
                        {
                            System.Console.WriteLine(e.Message);
                        }
                        break;
                    }
                case "2":
                    {
                        Console.WriteLine("Введите значение для удаления:");
                        string position = ReadValue();
                        try
                        {
                            if (!list.Remove(position))
                            {
                                if (list.IsEmpty())
                                {
                                    WriteEmpty();
                                }
                            }
                        }
                        catch (RemovingNonexistentNodeException e)
                        {
                            System.Console.WriteLine(e.Message);
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
                default:
                    {
                        Console.WriteLine("Что-то введено не так:)");
                        break;
                    }
            }
        }
    }
}
