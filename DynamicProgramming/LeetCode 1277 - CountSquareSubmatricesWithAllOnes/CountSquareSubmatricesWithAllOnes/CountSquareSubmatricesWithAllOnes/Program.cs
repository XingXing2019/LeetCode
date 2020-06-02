//应用动态规划思想，遍历数组，在每个点记录以该点为右下左，原点为左上角的区域内，正方形的最大边长。
//最大正方形的边长为改坐标左，上，左上三个位置的最小值加一。
//那么上述区域内，因为该点所增加的正方形个数就是这个区域内最大正方形的边长。将其加入res。
using System;

namespace CountSquareSubmatricesWithAllOnes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int CountSquares(int[][] matrix)
        {
            int res = 0;
            int row = matrix.Length, col = matrix[0].Length;
            for (int r = 0; r < row; r++)
            {
                for (int c = 0; c < col; c++)
                {
                    if (r != 0 && c != 0 && matrix[r][c] != 0)
                        matrix[r][c] = Math.Min(Math.Min(matrix[r - 1][c], matrix[r][c - 1]), matrix[r - 1][c - 1]) + 1;
                    res += matrix[r][c];
                }
            }
            return res;
        }
    }
}
