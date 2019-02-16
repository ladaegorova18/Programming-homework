using System;

namespace Spiral
{
    class Program
    {
        static void PrintSpiral(int[,] matrix)
        {
            var n = matrix.GetLength(0);
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

                Console.Write(matrix[i, j] + " ");
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

        static void PrintNormal(int[,] matrix)
        {
            var n = matrix.GetLength(0);
            var i = 0;
            foreach (var elem in matrix)
            {
                Console.Write(elem + " ");
                ++i;
                if (i % n == 0)
                {
                    Console.WriteLine();
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите n (n — нечетное):");
            var input = Console.ReadLine();
            int n = int.Parse(input);
            int[,] matrix = new int[n,n];
            var rnd = new Random();
            for (var i = 0; i < n; ++i)
            {
                for (var j = 0; j < n; ++j)
                {
                    matrix[i, j] = rnd.Next(0, 20);
                }
            }
            Console.WriteLine("Матрица в нормальном представлении:");
            PrintNormal(matrix);
            Console.WriteLine("Матрица по спирали:");
            PrintSpiral(matrix);
        }
    }
}
