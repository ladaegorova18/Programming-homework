using System;

namespace Hash_Table
{
    public class Program
    {
        private static Hash_Table CreateHashTable(string hashType)
        {
            switch (hashType)
            {
                case "1":
                    {
                        var hashFunction = new HashFunctionMod100();
                        return new Hash_Table(hashFunction);
                    }
                case "2":
                    {
                        var hashFunction = new HashFunctionByMultiplication();
                        return new Hash_Table(hashFunction);
                    }
                default:
                    {
                        var hashFunction = new HashFunctionCalledPerfect(); 
                        return new Hash_Table(hashFunction);
                    }
            }
        }

        static void Main(string[] args)
        {
            UserHashRequest();
            var hashType = Console.ReadLine();
            var hashTable = CreateHashTable(hashType);
            var filePath = @"text.txt";
            hashTable.FillingTheTable(filePath);
            var menu = new Menu(hashTable);
            menu.WorkWithMenu();
        }

        private static void UserHashRequest()
        {
            Console.WriteLine("Выберите, какую хэш-функцию использовать, нажмите:");
            Console.WriteLine("1, — встроенную в Visual Studio");
            Console.WriteLine("2, — основанную на умножении на простое число");
            Console.WriteLine("Любой другой символ — необычную, кодирующую группами по 4 символа");
        }
    }
}
