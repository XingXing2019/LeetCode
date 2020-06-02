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
            int row = grid.Length;
            if (row == 0)
                return 0;
            int col = grid[0].Length;
            int perimeter = 0;
            for (int r = 0; r < row; r++)
            {
                for (int c = 0; c < col; c++)
                {
                    if(grid[r][c] == 1)
                    {
                        if (r > 0)
                        {
                            if (grid[r - 1][c] == 0)
                                perimeter++;
                        }
                        else
                            perimeter++;
                        if (r < row - 1)
                        {
                            if (grid[r + 1][c] == 0)
                                perimeter++;
                        }
                        else
                            perimeter++;
                        if (c > 0)
                        {
                            if (grid[r][c - 1] == 0)
                                perimeter++;
                        }
                        else
                            perimeter++;
                        if (c < col - 1)
                        {
                            if (grid[r][c + 1] == 0)
                                perimeter++;
                        }
                        else
                            perimeter++;
                    }
                }
            }
            return perimeter;
        }
    }
}
