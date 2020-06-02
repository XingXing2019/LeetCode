using System;
using System.Linq;

namespace DiagonalTraverse
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] matrix = new int[3][];
            matrix[0] = new int[] {1, 2, 3};
            matrix[1] = new int[] {4, 5, 6};
            matrix[2] = new int[] {7, 8, 9};
            Console.WriteLine(FindDiagonalOrder(matrix));
        }
        static int[] FindDiagonalOrder(int[][] matrix)
        {
            if (matrix.Length == 0 || matrix[0].Length == 0) 
                return new int[0];
            int col = matrix.Length, row = matrix[0].Length;
            int m = 0, n = 0;
            int[] res = new int[row * col];
            bool flag = true;
            for (int i = 0; i < row * col; i++)
            {
                res[i] = matrix[m][n];
                if (flag)
                {
                    n += 1; m -= 1;
                }
                else
                {
                    n -= 1; m += 1;
                }
                if (m >= col)
                {
                    m -= 1; n += 2; flag = true;
                }
                else if (n >= row)
                {
                    n -= 1; m += 2; flag = false;
                }
                if (m < 0)
                {
                    m = 0; flag = false;
                }
                else if (n < 0)
                {
                    n = 0; flag = true;
                }
            }
            return res;
        }
    }
}
