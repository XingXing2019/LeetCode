//遍历数组，检查对角线上的数字是否符合条件。但需要注意不要越界。
using System;

namespace ToeplitzMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] matrix = new int[3][];
            matrix[0] = new int[] { 1, 2, 3, 4 };
            matrix[1] = new int[] { 5, 1, 2, 3 };
            matrix[2] = new int[] { 9, 5, 1, 2 };
            Console.WriteLine(IsToeplitzMatrix(matrix));
        }
        static bool IsToeplitzMatrix(int[][] matrix)
        {
            int row = matrix.Length;
            int col = matrix[0].Length;
            for (int c = 0; c < col; c++)
            {
                int p = 1;
                while (p < row && c + p < col)
                {
                    if (matrix[p][c + p] != matrix[0][c])
                        return false;
                    p++;
                }
            }
            for (int r = 1; r < row; r++)
            {
                int p = 1;
                while (r + p < row && p < col)
                {
                    if (matrix[r + p][p] != matrix[r][0])
                        return false;
                    p++;
                }
            }
            return true;
        }
    }
}
