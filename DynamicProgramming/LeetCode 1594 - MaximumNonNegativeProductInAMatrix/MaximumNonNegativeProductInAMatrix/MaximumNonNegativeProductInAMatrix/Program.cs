using System;

namespace MaximumNonNegativeProductInAMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] grid = new int[][]
            {
                new[] {1, -2, 1},
                new[] {1, -2, 1},
                new[] {3, -4, 1},
            };
            Console.WriteLine(MaxProductPath(grid));
        }
        static int MaxProductPath(int[][] grid)
        {
            int mod = 1_000_000_000 + 7;
            var dp = new long[grid.Length][][];
            for (int i = 0; i < dp.Length; i++)
                dp[i] = new long[grid[0].Length][];
            dp[0][0] = new long[] {grid[0][0], grid[0][0]};
            for (int i = 1; i < dp.Length; i++)
            {
                var num1 = grid[i][0] * dp[i - 1][0][0];
                var num2 = grid[i][0] * dp[i - 1][0][1];
                dp[i][0] = new [] {Math.Max(num1, num2), Math.Min(num1, num2)};
            }
            for (int i = 1; i < dp[0].Length; i++)
            {
                var num1 = grid[0][i] * dp[0][i - 1][0];
                var num2 = grid[0][i] * dp[0][i - 1][1];
                dp[0][i] = new [] {Math.Max(num1, num2), Math.Min(num1, num2)};
            }
            for (int i = 1; i < dp.Length; i++)
            {
                for (int j = 1; j < dp[0].Length; j++)
                {
                    var num1 = grid[i][j] * dp[i - 1][j][0];
                    var num2 = grid[i][j] * dp[i - 1][j][1];
                    var num3 = grid[i][j] * dp[i][j - 1][0];
                    var num4 = grid[i][j] * dp[i][j - 1][1];
                    var highest = Math.Max(Math.Max(Math.Max(num1, num2), num3), num4);
                    var lowest = Math.Min(Math.Min(Math.Min(num1, num2), num3), num4);
                    dp[i][j] = new[] {highest, lowest};
                }
            }
            return dp[^1][^1][0] < 0 ? -1 : (int) (dp[^1][^1][0] % mod);
        }
    }
}
