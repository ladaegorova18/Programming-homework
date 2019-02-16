using System;

namespace MatrixSorting
{
    class Program
    {
        static void Swap<T>(ref T a, ref T b) { T temp = a; a = b; b = temp;}

        static void Sorting(int[,] matrix, int rows, int columns)
        {
            for (var i = 0; i < columns; ++i)
            {
                for (var j = i + 1; j < columns; ++j)
                {
                    if (matrix[0, j] < matrix[0, i])
                    {
                        Swap(ref matrix[0,i], ref matrix[0, j]);

                        for (var k = 1; k < rows; ++k)
                        {
                            Swap(ref matrix[k, i], ref matrix[k, j]);
                        }
                    }
                }
            }
        }

        static void Print(int[,] matrix, int rows, int columns)
        {
            for (var i = 0; i < rows; ++i)
            {
                for (var j = 0; j < columns; ++j)
                {
                    Console.Write($"{matrix[i,j]} ");
                }

                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите количества строк и столбцов:");
            var input = Console.ReadLine();
            var stringArray = input.Split();
            int rows = int.Parse(stringArray[0]);
            int columns = int.Parse(stringArray[1]);
            int[,] matrix = new int[rows,columns];
            Random rnd = new Random();
            for (var i = 0; i < rows; ++i)
            {
                for (var j = 0; j < columns; ++j)
                {
                    matrix[i, j] = rnd.Next(0, 20);
                }
            }
            Console.WriteLine("Исходная матрица:");
            Print(matrix, rows, columns);
            Sorting(matrix, rows, columns);
            Console.WriteLine("Матрица после сортировки:");
            Print(matrix, rows, columns);
        }
    }
}
