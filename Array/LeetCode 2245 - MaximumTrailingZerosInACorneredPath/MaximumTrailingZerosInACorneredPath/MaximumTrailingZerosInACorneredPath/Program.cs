using System;
using System.Collections.Generic;

namespace MaximumTrailingZerosInACorneredPath
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] grid = new int[][]
            {
                new[] { 5, 1, 2, 1 },
                new[] { 5, 5, 8, 2 },
            };
            Console.WriteLine(MaxTrailingZeros(grid));
        }
        public static int MaxTrailingZeros(int[][] grid)
        {
            var res = 0;
            var rec = new int[grid.Length][][];
            var h = new int[grid.Length][][];
            var v = new int[grid.Length][][];
            for (int i = 0; i < grid.Length; i++)
            {
                rec[i] = new int[grid[0].Length][];
                h[i] = new int[grid[0].Length][];
                v[i] = new int[grid[0].Length][];
                for (int j = 0; j < grid[0].Length; j++)
                {
                    var two = Count(grid[i][j], 2);
                    var five = Count(grid[i][j], 5);
                    rec[i][j] = new[] { two, five };
                    if (j == 0)
                        h[i][j] = rec[i][j];
                    else
                        h[i][j] = new[] { rec[i][j][0] + h[i][j - 1][0], rec[i][j][1] + h[i][j - 1][1] };
                }
            }
            for (int j = 0; j < grid[0].Length; j++)
            {
                for (int i = 0; i < grid.Length; i++)
                {
                    if (i == 0)
                        v[i][j] = rec[i][j];
                    else
                        v[i][j] = new[] { rec[i][j][0] + v[i - 1][j][0], rec[i][j][1] + v[i - 1][j][1] };
                }
            }

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    var top = i == 0 ? new[] { 0, 0 } : new[] { v[i - 1][j][0], v[i - 1][j][1] };
                    var bottom = i == grid.Length - 1 ? new[] { 0, 0 } : new[] { v[^1][j][0] - v[i][j][0], v[^1][j][1] - v[i][j][1] };
                    var left = j == 0 ? new[] { 0, 0 } : new[] { h[i][j - 1][0], h[i][j - 1][1] };
                    var right = j == grid[0].Length - 1 ? new[] { 0, 0 } : new[] { h[i][^1][0] - h[i][j][0], h[i][^1][1] - h[i][j][1] };
                    var noTurnH = Math.Min(left[0] + rec[i][j][0] + right[0], left[1] + rec[i][j][1] + right[1]);
                    var noTurnV = Math.Min(top[0] + rec[i][j][0] + bottom[0], top[1] + rec[i][j][1] + bottom[1]);
                    var downLeft = Math.Min(top[0] + rec[i][j][0] + left[0], top[1] + rec[i][j][1] + left[1]);
                    var downRight = Math.Min(top[0] + rec[i][j][0] + right[0], top[1] + rec[i][j][1] + right[1]);
                    var upLeft = Math.Min(bottom[0] + rec[i][j][0] + left[0], bottom[1] + rec[i][j][1] + left[1]);
                    var upRight = Math.Min(bottom[0] + rec[i][j][0] + right[0], bottom[1] + rec[i][j][1] + right[1]);
                    var max = Math.Max(noTurnH, Math.Max(noTurnV, Math.Max(downLeft, Math.Max(downRight, Math.Max(upLeft, upRight)))));
                    res = Math.Max(res, max);
                }
            }
            return res;
        }

        public static int Count(int num, int mod)
        {
            if (num % mod != 0) return 0;
            return Count(num / mod, mod) + 1;
        }
    }
}
