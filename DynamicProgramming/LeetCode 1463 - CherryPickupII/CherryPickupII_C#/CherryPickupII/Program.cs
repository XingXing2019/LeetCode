using System;

namespace CherryPickupII
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] grid = new[]
            {
                new[] { 3, 1, 1 },
                new[] { 2, 5, 1 }
            };
            Console.WriteLine(CherryPickup(grid));
        }

        public static int CherryPickup(int[][] grid)
        {
            int m = grid.Length, n = grid[0].Length;
            var dp = new int[m][][];
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = new int[n][];
                for (int j = 0; j < dp[i].Length; j++)
                {
                    dp[i][j] = new int[n];
                }
            }
            return DFS(grid, dp, 0, 0, grid[0].Length - 1);
        }

        public static int DFS(int[][] grid, int[][][] dp, int x, int y1, int y2)
        {
            int m = grid.Length, n = grid[0].Length;
            if (x >= m || y1 < 0 || y1 >= n || y2 < 0 || y2 >= n)
                return 0;
            if (dp[x][y1][y2] != 0) return dp[x][y1][y2];
            var res = grid[x][y1];
            if (y1 != y2)
                res += grid[x][y2];
            int[] dir = { -1, 0, 1 };
            int max = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    max = Math.Max(max, DFS(grid, dp, x + 1, y1 + dir[i], y2 + dir[j]));
                }
            }
            dp[x][y1][y2] = res + max;
            return res + max;
        }
    }
}
