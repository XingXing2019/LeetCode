using System;

namespace NumberOfIncreasingPathsInAGrid
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int CountPaths(int[][] grid)
        {
            var dp = new long[grid.Length][];
            for (int i = 0; i < dp.Length; i++)
                dp[i] = new long[grid[0].Length];
            long res = 0, mod = 1_000_000_000 + 7;
            for (int x = 0; x < grid.Length; x++)
            {
                for (int y = 0; y < grid[0].Length; y++)
                {
                    res += DFS(grid, x, y, dp);
                }
            }
            return (int)(res % mod);
        }

        public long DFS(int[][] grid, int x, int y, long[][] dp)
        {
            if (dp[x][y] != 0)
                return dp[x][y];
            int[] dir = { 1, 0, -1, 0, 1 };
            long res = 1, mod = 1_000_000_000 + 7;
            for (int i = 0; i < 4; i++)
            {
                int newX = x + dir[i], newY = y + dir[i + 1];
                if (newX < 0 || newX >= grid.Length || newY < 0 || newY >= grid[0].Length || grid[newX][newY] <= grid[x][y])
                    continue;
                res = (res + DFS(grid, newX, newY, dp)) % mod;
            }
            return dp[x][y] = res;
        }
    }
}
