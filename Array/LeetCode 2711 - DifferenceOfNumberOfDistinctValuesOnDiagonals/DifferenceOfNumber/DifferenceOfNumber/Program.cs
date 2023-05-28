using System;
using System.Collections.Generic;

namespace DifferenceOfNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int[][] DifferenceOfDistinctValues(int[][] grid)
        {
            var res = new int[grid.Length][];
            for (int x = 0; x < grid.Length; x++)
            {
                res[x] = new int[grid[x].Length];
                for (int y = 0; y < grid[0].Length; y++)
                {
                    res[x][y] = Count(grid, x, y);
                }
            }
            return res;
        }

        public int Count(int[][] grid, int x, int y)
        {
            var leftTop = new HashSet<int>();
            var rightBottom = new HashSet<int>();
            int newX = x - 1, newY = y - 1;
            while (newX >= 0 && newY >= 0)
            {
                leftTop.Add(grid[newX][newY]);
                newX--;
                newY--;
            }
            newX = x + 1;
            newY = y + 1;
            while (newX < grid.Length && newY < grid[0].Length)
            {
                rightBottom.Add(grid[newX][newY]);
                newX++;
                newY++;
            }
            return Math.Abs(leftTop.Count - rightBottom.Count);
        }
    }
}
