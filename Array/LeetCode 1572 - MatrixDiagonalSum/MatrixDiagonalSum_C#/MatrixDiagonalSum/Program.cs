using System;
using System.Globalization;

namespace MatrixDiagonalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int DiagonalSum(int[][] mat)
        {
            int res = 0, index = 0;
            foreach (var row in mat)
            {
                res += row[index];
                res += row[^++index];
            }
            if (mat.Length % 2 != 0)
                res -= mat[mat.Length / 2][mat.Length / 2];
            return res;
        }
    }
}
