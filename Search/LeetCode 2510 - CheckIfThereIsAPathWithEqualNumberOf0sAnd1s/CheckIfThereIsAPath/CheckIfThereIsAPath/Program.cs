using System;
using System.Collections.Generic;

namespace CheckIfThereIsAPath
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] grid = new[]
            {
                new[] { 1, 1, 0 },
                new[] { 0, 0, 1 },
                new[] { 1, 0, 0 },
            };
            Console.WriteLine(IsThereAPath(grid));
        }

        public static bool IsThereAPath(int[][] grid)
        {
            var dp = new Dictionary<int, bool>[grid.Length][];
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = new Dictionary<int, bool>[grid[0].Length];
                for (int j = 0; j < dp[i].Length; j++)
                {
                    dp[i][j] = new Dictionary<int, bool>();
                }
            }
            return DFS(grid, 0, 0, 0, dp);
        }

        public static bool DFS(int[][] grid, int x, int y, int diff, Dictionary<int, bool>[][] dp)
        {
            if (x >= grid.Length || y >= grid[0].Length)
                return false;
            diff += grid[x][y] == 0 ? 1 : -1;
            if (dp[x][y].ContainsKey(diff))
                return dp[x][y][diff];
            if (x == grid.Length - 1 && y == grid[0].Length - 1)
                return diff == 0;
            var res = DFS(grid, x + 1, y, diff, dp) || DFS(grid, x, y + 1, diff, dp);
            return dp[x][y][diff] = res;
        }
    }
}
