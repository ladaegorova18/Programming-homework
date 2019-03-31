using System;
using System.IO;

namespace HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            var hashTable = new HashTable();
            var filePath = @"text.txt";
            using (var stream = new StreamReader(filePath))
            {
                while(stream.Peek() >= 0)
                {
                    var str = stream.ReadLine();
                    string[] words = str.Split();
                    foreach (string word in words)
                    {
                        hashTable.AddData(word);
                    }
                }
            }

            var menu = new Menu(hashTable);
            menu.WorkWithMenu();
        }
    }
}
