using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace DisconnectPathInABinaryMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] grid = new[]
            {
                new[] { 1, 1, 1 },
                new[] { 1, 0, 1 },
                new[] { 1, 1, 1 },
            };
            Console.WriteLine(IsPossibleToCutPath(grid));
        }

        public static bool IsPossibleToCutPath(int[][] grid)
        {
            if (grid.Length * grid[0].Length < 3) return false;
            return DFS(grid, 0, 0, new HashSet<string>(), new List<HashSet<string>>());
        }

        private static bool DFS(int[][] grid, int x, int y, HashSet<string> path, List<HashSet<string>> paths)
        {
            int m = grid.Length, n = grid[0].Length;
            if (x >= m || y >= n || grid[x][y] == 0)
                return true;
            bool isStart = x == 0 && y == 0, isEnd = x == m - 1 && y == n - 1;
            if (!isStart && !isEnd)
                path.Add($"{x}:{y}");
            if (x == m - 1 && y == n - 1)
            {
                if (paths.Any(x => x.All(x => !path.Contains(x))))
                    return false;
                paths.Add(new HashSet<string>(path));
            }
            var res = DFS(grid, x + 1, y, path, paths) && DFS(grid, x, y + 1, path, paths);
            if (!isStart || !isEnd)
                path.Remove($"{x}:{y}");
            return res;
        }
    }
}
