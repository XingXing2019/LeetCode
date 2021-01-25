using System;
using System.Collections.Generic;

namespace NumberOfDistinctIslands
{
    class Program
    {
        static void Main(string[] args)
        {
            var grid = new int[][]
            {
                new[] {1, 1, 0, 1, 1},
                new[] {1, 0, 0, 0, 0},
                new[] {0, 0, 0, 0, 1},
                new[] {1, 1, 0, 1, 1},
            };
            Console.WriteLine(NumDistinctIslands(grid));
        }
        static int NumDistinctIslands(int[][] grid)
        {
            int[][] mark = new int[grid.Length][];
            for (int i = 0; i < grid.Length; i++)
                mark[i] = new int[grid[0].Length];
            var distinctIslands = new HashSet<string>();
            for (int x = 0; x < grid.Length; x++)
            {
                for (int y = 0; y < grid[0].Length; y++)
                {
                    if (mark[x][y] == 0 && grid[x][y] == 1)
                    {
                        var key = "";
                        DFS(grid, mark, x, y, x, y, ref key);
                        distinctIslands.Add(key);
                    }
                }
            }
            return distinctIslands.Count;
        }

        static void DFS(int[][] grid, int[][] mark, int x, int y, int oX, int oY, ref string key)
        {
            mark[x][y] = 1;
            key += $"{oX - x}.{oY - y}.";
            int[] dx = {-1, 1, 0, 0};
            int[] dy = {0, 0, -1, 1};
            for (int i = 0; i < 4; i++)
            {
                int newX = dx[i] + x;
                int newY = dy[i] + y;
                if(newX < 0 || newX >= grid.Length || newY < 0 || newY >= grid[0].Length)
                    continue;
                if(mark[newX][newY] == 0 && grid[newX][newY] == 1)
                    DFS(grid, mark, newX, newY, oX, oY, ref key);
            }
        }
    }
}
