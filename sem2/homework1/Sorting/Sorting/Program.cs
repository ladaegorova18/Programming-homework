using System;

namespace Sorting
{
    class Program
    {
        static void Swap<T>(ref T a, ref T b) { T temp = a; a = b; b = temp;  }
        static int Partition(int[] array, int begin, int end)
        {
            var key = array[end - 1];
            var i = begin;
            for (var j = begin; j < end; ++j)
            {
                if (array[j] <= key)
                {
                    Swap(ref array[i], ref array[j]);
                    ++i;
                }
            }
            return i;
        }
        static void QuickSort(int[] array, int begin, int end)
        {
            if (begin < end)
            {
                var pivot = Partition(array, begin, end);
                QuickSort(array, begin, pivot - 1);
                QuickSort(array, pivot, end);
            }
        }
        static void Main(string[] args)
        {
            int[] array = new int[10] {5, 2, 7, 1, -8, 0, 9, 5, 3, -2};
            QuickSort(array, 0, 10);
            Console.WriteLine("Отсортированный массив:");
            for (var i = 0; i < 10; ++i)
            {
                Console.Write($"{array[i]} ");
            }
        }
    }
}
