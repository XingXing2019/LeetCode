//创建和A大小相同的二维数组dp，每个位置代表以该点为结尾的路径能达到的最小值。
//将dp第一行设为与A第一行相同。从第二行开始遍历，每个位置等于当前位置值加上其上一行相邻位置中最小的值。注意不要越界。
//遍历完成后，最后一行的最小值即为结果。
using System;

namespace MinimumFallingPathSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] A = new int[3][];
            A[0] = new int[3] { 1, 2, -23 };
            A[1] = new int[3] { 4, 35, -6 };
            A[2] = new int[3] { -7, 8, 9 };
            Console.WriteLine(MinFallingPathSum(A));
        }
        static int MinFallingPathSum(int[][] A)
        {
            int row = A.Length, col = A[0].Length;
            int[,] dp = new int[row, col];
            for (int c = 0; c < col; c++)
                dp[0, c] = A[0][c];
            for (int r = 1; r < row; r++)
            {
                for (int c = 0; c < col; c++)
                {
                    int path1 = int.MaxValue, path2 = dp[r - 1, c], path3 = int.MaxValue;
                    if (c > 0)
                        path1 = dp[r - 1, c - 1];
                    if (c < col - 1)
                        path3 = dp[r - 1, c + 1];
                    int minPath = Math.Min(path1, Math.Min(path2, path3));
                    dp[r, c] = minPath + A[r][c];
                }
            }
            int res = int.MaxValue;
            for (int c = 0; c < col; c++)
                res = Math.Min(res, dp[row - 1, c]);
            return res;
        }
    }
}
