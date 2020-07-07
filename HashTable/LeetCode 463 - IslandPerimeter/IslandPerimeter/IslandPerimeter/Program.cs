//遍历每一个格子，如果值是1，则检查其上下左右四个格子有多少0，或者有几个边在边界。没出现一个0，或者一个边界，则令perimeter加一。
using System;

namespace IslandPerimeter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int IslandPerimeter(int[][] grid)
        {
            if (grid.Length == 0 || grid[0].Length == 0) return 0;
            int perimeter = 0;
            int row = grid.Length, col = grid[0].Length;
            for (int r = 0; r < row; r++)
            {
                for (int c = 0; c < col; c++)
                {
                    if(grid[r][c] == 0) continue;
                    int count = 4;
                    if (r > 0 && grid[r - 1][c] == 1) count--;
                    if (r < row - 1 && grid[r + 1][c] == 1) count--;
                    if (c > 0 && grid[r][c - 1] == 1) count--;
                    if (c < col - 1 && grid[r][c + 1] == 1) count--;
                    perimeter += count;
                }
            }
            return perimeter;
        }

        static int IslandPerimeter_DirectionArray(int[][] grid)
        {
            var perimeter = 0;
            if (grid.Length == 0 || grid[0].Length == 0) return perimeter;
            int[] dr = {-1, 1, 0, 0};
            int[] dc = {0, 0, -1, 1};
            for (int r = 0; r < grid.Length; r++)
            {
                for (int c = 0; c < grid[0].Length; c++)
                {
                    if(grid[r][c] == 0) continue;
                    perimeter += 4;
                    for (int i = 0; i < 4; i++)
                    {
                        int newR = dr[i] + r;
                        int newC = dc[i] + c;
                        if(newR < 0 || newR >= grid.Length || newC < 0 || newC >= grid[0].Length) continue;
                        if (grid[newR][newC] == 1) perimeter--;
                    }
                }
            }
            return perimeter;
        }
    }
}
