using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_travelling_salesman
{
    public static class Properties
    {
        public static int[,] Matrix =         //7
        {
            {0, 1, 5, 2, 3, 2, 8},
            {1, 0, 1, 1, 2, 1, 3},
            {5, 1, 0, 2, 3, 5, 6},
            {2, 1, 2, 0, 1, 2, 3},
            {3, 2, 3, 1, 0, 1, 2},
            {2, 1, 5, 2, 1, 0, 1},
            {8, 3, 6, 3, 2, 1, 0}
        };

        public static int CityCount = (int) Math.Sqrt(Matrix.Length);

        public static void Print<T>(T[,] array)
        {
            for (int i = 0; i < Math.Sqrt(array.Length); i++)
            {
                for (int j = 0; j < Math.Sqrt(array.Length); j++)
                {
                    Console.Write($"{array[i, j]:f4} ");
                }

                Console.WriteLine();
            }
        }
    }
}