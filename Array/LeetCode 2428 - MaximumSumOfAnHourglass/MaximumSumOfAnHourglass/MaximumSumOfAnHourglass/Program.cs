using System;

namespace MaximumSumOfAnHourglass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var grid = new int[][]
            {
                new[] { 5, 6, 7, 8, 7 },
                new[] { 0, 6, 6, 9, 1 },
                new[] { 2, 5, 8, 0, 9 },
            };
            Console.WriteLine(MaxSum(grid));
        }
        public static int MaxSum(int[][] grid)
        {
            var prefix = new int[grid.Length][];
            for (int i = 0; i < grid.Length; i++)
            {
                prefix[i] = new int[grid[0].Length];
                for (int j = 0; j < prefix[0].Length; j++)
                    prefix[i][j] = j == 0 ? grid[i][j] : grid[i][j] + prefix[i][j - 1];
            }
            var res = 0;
            for (int i = 0; i <= grid.Length - 3; i++)
            {
                for (int j = 0; j <= grid[0].Length - 3; j++)
                {
                    var top = prefix[i][j + 2] - (j == 0 ? 0 : prefix[i][j - 1]);
                    var mid = prefix[i + 1][j + 2] - (j == 0 ? 0 : prefix[i + 1][j - 1]);
                    var bottom = prefix[i + 2][j + 2] - (j == 0 ? 0 : prefix[i + 2][j - 1]);
                    res = Math.Max(res, top + mid + bottom - grid[i + 1][j] - grid[i + 1][j + 2]);
                }
            }
            return res;
        }
    }
}
