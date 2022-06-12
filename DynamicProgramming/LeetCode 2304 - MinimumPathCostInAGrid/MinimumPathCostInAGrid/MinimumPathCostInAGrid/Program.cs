using System;
using System.Collections.Generic;
using Microsoft.VisualBasic.CompilerServices;

namespace MinimumPathCostInAGrid
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] grid = new[]
            {
                new[] { 5, 3 },
                new[] { 4, 0 },
                new[] { 2, 1 },
            };
            int[][] moveCost = new[]
            {
                new[] { 9, 8 },
                new[] { 1, 5 },
                new[] { 10, 12 },
                new[] { 18, 6 },
                new[] { 2, 4 },
                new[] { 14, 3 },
            };
            Console.WriteLine(MinPathCost(grid, moveCost));
        }

        public static int MinPathCost(int[][] grid, int[][] moveCost)
        {
            if (grid.Length == 0) return 0;
            var dict = new Dictionary<int, Dictionary<int, int>>();
            for (int i = 0; i < moveCost.Length; i++)
            {
                if (!dict.ContainsKey(i))
                    dict[i] = new Dictionary<int, int>();
                for (int j = 0; j < moveCost[i].Length; j++)
                    dict[i][j] = moveCost[i][j];
            }
            var dp = new int[grid.Length][];
            var res = int.MaxValue;
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = new int[grid[0].Length];
                for (int j = 0; j < dp[i].Length; j++)
                    dp[i][j] = i == 0 ? grid[i][j] : int.MaxValue;
            }
            for (int i = 1; i < dp.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    for (int k = 0; k < grid[0].Length; k++)
                    {
                        var from = grid[i - 1][k];
                        dp[i][j] = Math.Min(dp[i][j], dp[i - 1][k] + dict[from][j] + grid[i][j]);
                        if (i != dp.Length - 1) continue;
                        res = Math.Min(res, dp[i][j]);
                    }
                }
            }
            return res;
        }
    }
}
