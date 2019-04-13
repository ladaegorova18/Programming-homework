using System;

namespace MatrixSorting
{
    class Program
    {
        static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        static void Sorting(int[,] matrix)
        {
            for (var i = 0; i < matrix.GetLength(1); ++i)
            {
                for (var j = i + 1; j < matrix.GetLength(1); ++j)
                {
                    if (matrix[0, j] < matrix[0, i])
                    {
                        Swap(ref matrix[0, i], ref matrix[0, j]);

                        for (var k = 1; k < matrix.GetLength(0); ++k)
                        {
                            Swap(ref matrix[k, i], ref matrix[k, j]);
                        }
                    }
                }
            }
        }

        static void Print(int[,] matrix)
        {
            var i = 0;
            foreach (var elem in matrix)
            {
                Console.Write(elem + " ");
                ++i;
                if (i % matrix.GetLength(1) == 0)
                {
                    Console.WriteLine();
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите количества строк и столбцов:");
            var input = Console.ReadLine();
            var stringArray = input.Split();
            int rows = int.Parse(stringArray[0]);
            int columns = int.Parse(stringArray[1]);
            var matrix = new int[rows, columns];
            var rnd = new Random();
            for (var i = 0; i < rows; ++i)
            {
                for (var j = 0; j < columns; ++j)
                {
                    matrix[i, j] = rnd.Next(0, 20);
                }
            }
            Console.WriteLine("Исходная матрица:");
            Print(matrix);
            Sorting(matrix);
            Console.WriteLine("Матрица после сортировки:");
            Print(matrix);
        }
    }
}
