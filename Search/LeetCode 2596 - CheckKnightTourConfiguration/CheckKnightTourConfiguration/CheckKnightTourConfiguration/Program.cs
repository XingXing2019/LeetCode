using System;

namespace CheckKnightTourConfiguration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public bool CheckValidGrid(int[][] grid)
        {
            int[][] moves =
            {
                new[] { -2, 1 }, new[] { -1, 2 }, new[] { 1, 2 }, new[] { 2, 1 }, 
                new[] { 2, -1 }, new[] { 1, -2 }, new[] { -2, -1 }, new[] { -1, -2 }
            };
            return DFS(grid, moves, 0, 0, 0);
        }

        public bool DFS(int[][] grid, int[][] moves, int x, int y, int expected)
        {
            if (x < 0 || x >= grid.Length || y < 0 || y >= grid[0].Length || grid[x][y] != expected)
                return false;
            if (expected == grid.Length * grid[0].Length - 1)
                return true;
            for (int i = 0; i < moves.Length; i++)
            {
                int newX = x + moves[i][0], newY = y + moves[i][1];
                if (DFS(grid, moves, newX, newY, expected + 1))
                    return true;
            }
            return false;
        }
    }
}
