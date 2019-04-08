using System;

namespace HashTable
{
    class Menu
    {
        private void TextMenu()
        {
            Console.WriteLine("Это меню хэш-таблицы. Нажмите:");
            Console.WriteLine("1, чтобы добавить указанное слово;");
            Console.WriteLine("2, чтобы удалить указанное слово из хэш-таблицы;");
            Console.WriteLine("3, чтобы найти указанное слово;");
            Console.WriteLine("4, чтобы выйти.");
        }

        public void WorkWithMenu()
        {
            TextMenu();
            string key = Console.ReadLine();
            while (key != "4")
            {
                Options(key);
                TextMenu();
                key = Console.ReadLine();
            }
            Console.WriteLine("До свидания!");
            hashTable.ClearTable();
        }

        private void Options(string key)
        {
            switch (key)
            {
                case "1":
                    {
                        Console.WriteLine("Введите слово для добавления:");
                        string data = Console.ReadLine();
                        hashTable.AddData(data);
                        break;
                    }
                case "2":
                    {
                        Console.WriteLine("Введите слово для удаления:");
                        string data = Console.ReadLine();
                        hashTable.RemoveData(data);
                        break;
                    }
                case "3":
                    {
                        Console.WriteLine("Введите слово для поиска:");
                        string data = Console.ReadLine();
                        if (hashTable.Exists(data))
                        {
                            Console.WriteLine("Слово есть в таблице)");
                        }
                        else
                        {
                            Console.WriteLine("Такого слова нет!");
                        }
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        public Menu(Table hashTable)
        {
            this.hashTable = hashTable;
        }

        private Table hashTable;
    }
}
