using System;
using System.IO;

namespace HashTable
{
    public class Program
    {
        private static Table CreateHashTable(string hashType)
        {
            switch (hashType)
            {
                case "1":
                    {
                        var hashFunction = new HashFunctionFromVS();
                        return new Table(hashFunction);
                    }
                case "2":
                    {
                        var hashFunction = new HashFunctionByMultiplication();
                        return new Table(hashFunction);
                    }
                default:
                    {
                        var hashFunction = new HashFunctionCalledPerfect(); 
                        return new Table(hashFunction);
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
