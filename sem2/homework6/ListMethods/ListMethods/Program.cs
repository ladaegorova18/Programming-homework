using System;
using System.Collections.Generic;

namespace ListMethods
{
    class Program
    {
        private static void Main(string[] args)
        {
            List<int> list = new List<int>() { 2, 4, 1, 1, 7, -1, 10, -3 };
            var mapList = Methods.Map(list, x => x * 3);
            var filterList = Methods.Filter(list, x => (x % 2 == 0));
            var result = Methods.Fold(list, 1, (acc, elem) => acc * elem);
            Console.WriteLine("Исходный список:");
            PrintList(list);
            Console.WriteLine("Список после умножения всех элементов на 3:");
            PrintList(mapList);
            Console.WriteLine("Список, в котором оставили только четные элементы:");
            PrintList(filterList);
            Console.WriteLine("Значение, полученное в результе умножения каждого элемента на накопленное: " + result);
        }

        private static void PrintList(List<int> list)
        {
            foreach (var cell in list)
            {
                Console.Write(cell + " ");
            }
            Console.WriteLine();
        }
    }
}