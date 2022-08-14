using System;

namespace LargestLocalValuesInAMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] grid = new[]
            {
                new[] { 9, 9, 8, 1 },
                new[] { 5, 6, 2, 6 },
                new[] { 8, 2, 6, 4 },
                new[] { 6, 2, 2, 2 },
            };
            Console.WriteLine(LargestLocal(grid));
        }

        public static int[][] LargestLocal(int[][] grid)
        {
            int n = grid.Length;
            var maxGrid = new int[n][];
            for (int i = 1; i <= n - 2; i++)
            {
                maxGrid[i] = new int[n];
                for (int j = 1; j <= n - 2; j++)
                {
                    var max = 0;
                    max = Math.Max(max, grid[i - 1][j - 1]);
                    max = Math.Max(max, grid[i - 1][j]);
                    max = Math.Max(max, grid[i - 1][j + 1]);
                    max = Math.Max(max, grid[i][j - 1]);
                    max = Math.Max(max, grid[i][j]);
                    max = Math.Max(max, grid[i][j + 1]);
                    max = Math.Max(max, grid[i + 1][j - 1]);
                    max = Math.Max(max, grid[i + 1][j]);
                    max = Math.Max(max, grid[i + 1][j + 1]);
                    maxGrid[i][j] = max;
                }
            }
            var res = new int[n - 2][];
            for (int i = 1; i < n - 1; i++)
            {
                res[i - 1] = new int[n - 2];
                Array.Copy(maxGrid[i], 1, res[i - 1], 0, n - 2);
            }
            return res;
        }
    }
}
