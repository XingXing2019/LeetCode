using System;

namespace MaximumNumberOfMovesInAGrid
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] grid = new int[][]
            {
                new[] { 3, 2, 4 },
                new[] { 2, 1, 9 },
                new[] { 1, 1, 7 },
            };
            Console.WriteLine(MaxMoves(grid));
        }

        public static int MaxMoves(int[][] grid)
        {
            var dp = new int[grid.Length][];
            var res = 0;
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = new int[grid[0].Length];
                dp[i][^1] = 1;
            }
            int[][] dir = new[] { new[] { -1, 1 }, new[] { 0, 1 }, new[] { 1, 1 } };
            for (int y = grid[0].Length - 2; y >= 0; y--)
            {
                for (int x = 0; x < grid.Length; x++)
                {
                    var max = 0;
                    for (int i = 0; i < 3; i++)
                    {
                        int newX = x + dir[i][0], newY = y + dir[i][1];
                        if (newX < 0 || newX >= grid.Length || grid[newX][newY] <= grid[x][y]) continue;
                        max = Math.Max(max, dp[newX][newY]);
                    }
                    dp[x][y] = max + 1;
                    if (y == 0)
                        res = Math.Max(res, dp[x][y]);
                }
            }
            return res - 1;
        }
    }
}
