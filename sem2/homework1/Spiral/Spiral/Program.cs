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
            var count = n * n;
            var rowsDirection = 0;
            var columnsDirection = 0;
            var distance = 0;
            var distanceLeft = 0;
            bool increaseDistance = true;
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
                        increaseDistance = true;
                    }

                    if (increaseDistance)
                    {
                        ++distance;
                    }
                    increaseDistance = !increaseDistance;
                    distanceLeft = distance;
                }

                Console.Write(matrix[i, j] + " ");
                i += rowsDirection;
                j += columnsDirection;
                --distanceLeft;
                --count;
            }
        }

        static void PrintNormal(int[,] matrix)
        {
            var n = matrix.GetLength(0);
            var count = 0;
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    Console.Write(matrix[i, j] + " ");
                    ++count;
                }

                if (count % n == 0)
                {
                    Console.WriteLine();
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите n (n — нечетное и положительное):");
            var input = Console.ReadLine();
            int n = int.Parse(input);
            if (n < 0 || n % 2 != 1)
            {
                Console.WriteLine("n должно быть нечетным и положительным)");
                return;
            }
            var matrix = new int[n, n];
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
