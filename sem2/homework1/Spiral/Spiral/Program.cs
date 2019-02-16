using System;

namespace Spiral
{
    class Program
    {
        static void PrintSpiral(int[,] matrix, int n)
        {
            var center = n / 2;
            var i = center;
            var j = center;
            var rowsDirection = 0;
            var columnsDirection = 0;
            var count = n * n;
            var distance = 0;
            var distanceLeft = 0;
            bool inreaseDistance = true;
            while (count > 0)
            {
                if (distanceLeft == 0)
                {
                    if (rowsDirection != 0)
                    {
                        columnsDirection = rowsDirection;
                        rowsDirection = 0;
                    }
                    else if (columnsDirection != 0)
                    {
                        rowsDirection = -columnsDirection;
                        columnsDirection = 0;
                    }
                    else
                    {
                        rowsDirection = 0;
                        columnsDirection = -1;
                        inreaseDistance = true;
                    }

                    if (inreaseDistance) { ++distance; }
                    inreaseDistance = !inreaseDistance;
                    distanceLeft = distance;
                }

                Console.Write($"{matrix[i, j]} ");
                i += rowsDirection;
                j += columnsDirection;
                --distanceLeft;
                --count;
                if (count % n == 0)
                {
                    Console.WriteLine();
                }
            }
        }

        static void PrintNormal(int[,] matrix, int n)
        {
            for (var i = 0; i < n; ++i)
            {
                for (var j = 0; j < n; ++j)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите n:");
            var input = Console.ReadLine();
            int n = int.Parse(input);
            int[,] matrix = new int[n,n];
            Console.WriteLine("Введите значения матрицы:");
            for (var i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    var inputNumber = Console.ReadLine();
                    int number = int.Parse(inputNumber);
                    matrix[i, j] = number;
                }
            }
            Console.WriteLine("Матрица в нормальном представлении:");
            PrintNormal(matrix, n);
            Console.WriteLine("Матрица по спирали:");
            PrintSpiral(matrix, n);
        }
    }
}
