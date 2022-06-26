using System;

namespace CheckIfMatrixIsXMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] grid = new[]
            {
                new[] { 6, 0, 0, 0, 0, 0, 0, 18 },
                new[] { 0, 17, 0, 0, 0, 0, 18, 0 },
                new[] { 0, 0, 13, 0, 0, 17, 0, 0 },
                new[] { 0, 0, 0, 9, 18, 0, 0, 0 },
                new[] { 0, 0, 0, 2, 20, 0, 0, 0 },
                new[] { 0, 0, 20, 0, 0, 3, 0, 0 },
                new[] { 0, 14, 0, 0, 0, 0, 11, 0 },
                new[] { 19, 0, 0, 0, 0, 0, 0, 9 },
            };
            Console.WriteLine(CheckXMatrix(grid));
        }

        public static bool CheckXMatrix(int[][] grid)
        {
            var n = grid.Length;
            var zero = n * n - (n % 2 == 0 ? 2 * n : 2 * n - 1);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] != 0) continue;
                    zero--;
                }
            }
            if (zero != 0) return false;
            for (int i = 0; i < n; i++)
            {
                if (grid[i][i] == 0 || grid[i][^(i + 1)] == 0)
                    return false;
            }
            return true;
        }
    }
}
