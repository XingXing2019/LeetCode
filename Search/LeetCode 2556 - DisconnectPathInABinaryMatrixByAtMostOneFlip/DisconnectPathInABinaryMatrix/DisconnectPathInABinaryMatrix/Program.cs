using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace DisconnectPathInABinaryMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] grid = new[]
            {
                new[] { 1, 1, 1 },
                new[] { 1, 0, 0 },
                new[] { 1, 1, 1 },
            };
            Console.WriteLine(IsPossibleToCutPath(grid));
        }

        public static bool IsPossibleToCutPath(int[][] grid)
        {
            if (grid.Length * grid[0].Length < 3) return false;
            var res = 0;
            var dict = new Dictionary<string, int>();
            DFS(grid, 0, 0, dict, new HashSet<string>(), ref res);
            if (res < 2) return true;
            foreach (var pos in dict.Keys)
            {
                if (pos == "0:0" || pos == $"{grid.Length - 1}:{grid[0].Length - 1}") continue;
                if (dict[pos] == res)
                    return true;
            }
            return false;
        }

        private static void DFS(int[][] grid, int x, int y, Dictionary<string, int> dict, HashSet<string> visited, ref int res)
        {
            if (x < 0 || x >= grid.Length || y < 0 || y >= grid[0].Length || grid[x][y] == 0)
                return;
            if (!dict.ContainsKey($"{x}:{y}"))
                dict[$"{x}:{y}"] = 0;
            dict[$"{x}:{y}"]++;
            if (x == grid.Length - 1 && x == grid[0].Length - 1)
                res++;
            if (!visited.Add($"{x}:{y}")) return;
            DFS(grid, x + 1, y, dict, visited, ref res);
            DFS(grid, x, y + 1, dict, visited, ref res);
            visited.Remove($"{x}:{y}");
        }
    }
}
