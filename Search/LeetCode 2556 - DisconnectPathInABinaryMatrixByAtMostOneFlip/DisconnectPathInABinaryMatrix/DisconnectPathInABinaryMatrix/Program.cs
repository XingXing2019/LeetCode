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
            if (!DFS(grid, 0, 0)) return true;
            grid[0][0] = 1;
            return !DFS(grid, 0, 0);
        }

        private static bool DFS(int[][] grid, int x, int y)
        {
            if (x >= grid.Length || y >= grid[0].Length || grid[x][y] == 0)
                return false;
            if (x == grid.Length - 1 && y == grid[0].Length - 1)
                return true;
            grid[x][y] = 0;
            return DFS(grid, x + 1, y) || DFS(grid, x, y + 1);
        }
    }
}
