using System;
using System.Collections.Generic;

namespace MinimumMovesToSpreadStonesOverGrid
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] grid = new int[][]
            {
                new[] { 9, 0, 0 },
                new[] { 0, 0, 0 },
                new[] { 0, 0, 0 }
            };
            Console.WriteLine(MinimumMoves(grid));
        }

        public static int MinimumMoves(int[][] grid)
        {
            var extras = new List<int[]>();
            var zeros = new List<int[]>();
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == 0)
                        zeros.Add(new[] { i, j, 0 });
                    for (int k = 0; k < grid[i][j] - 1; k++)
                    {
                        extras.Add(new[] { i, j });
                    }
                }
            }
            var res = int.MaxValue;
            Backtracking(extras, zeros, 0, 0, ref res);
            return res;
        }

        public static void Backtracking(List<int[]> extras, List<int[]> zeros, int start, int moves, ref int res)
        {
            if (start == extras.Count)
            {
                res = Math.Min(res, moves);
                return;
            }
            foreach (var zero in zeros)
            {
                if (zero[2] == 1) continue;
                zero[2] = 1;
                Backtracking(extras, zeros, start + 1, moves + Math.Abs(zero[0] - extras[start][0]) + Math.Abs(zero[1] - extras[start][1]), ref res);
                zero[2] = 0;
            }
        }
    }
}
