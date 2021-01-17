using System;

namespace LargestSubmatrixWithRearrangements
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int LargestSubmatrix(int[][] matrix)
        {
            for (int j = 0; j < matrix[0].Length; j++)
            {
                for (int i = 0; i < matrix.Length; i++)
                {
                    if (matrix[i][j] == 1 && i != 0)
                        matrix[i][j] = matrix[i - 1][j] + 1;
                }
            }
            var res = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                Array.Sort(matrix[i]);
                for (int j = matrix[0].Length - 1; j >= 0; j--)
                    res = Math.Max(res, matrix[i][j] * (matrix[0].Length - j));
            }
            return res;
        }
    }
}
