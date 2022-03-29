using System;

namespace PathWithMaximumMinimumValue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] grid =
            {
                new[] { 5, 4 },
                new[] { 1, 2 },
            };
            Console.WriteLine(MaximumMinimumPath(grid));
        }

        public static int MaximumMinimumPath(int[][] grid)
        {
            int li = int.MaxValue, hi = int.MinValue;
            for (int x = 0; x < grid.Length; x++)
            {
                for (int y = 0; y < grid[0].Length; y++)
                {
                    li = Math.Min(li, grid[x][y]);
                    hi = Math.Max(hi, grid[x][y]);
                }
            }
            while (li <= hi)
            {
                int mid = li + (hi - li) / 2;
                var visited = new bool[grid.Length][];
                for (int i = 0; i < grid.Length; i++)
                    visited[i] = new bool[grid[0].Length];
                if (DFS(grid, visited, 0, 0, mid))
                    li = mid + 1;
                else
                    hi = mid - 1;
            }
            return hi;
        }

        public static bool DFS(int[][] grid, bool[][] visited, int x, int y, int min)
        {
            if (x < 0 || x >= grid.Length || y < 0 || y >= grid[0].Length || visited[x][y] || grid[x][y] < min)
                return false;
            visited[x][y] = true;
            if (x == grid.Length - 1 && y == grid[0].Length - 1)
                return true;
            return DFS(grid, visited, x - 1, y, min) ||
                   DFS(grid, visited, x + 1, y, min) ||
                   DFS(grid, visited, x, y - 1, min) ||
                   DFS(grid, visited, x, y + 1, min);
        }
    }
}
