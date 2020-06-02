using System;

namespace CountNegativeNumbersInASortedMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] grid = new int[1][];
            grid[0] = new int[] { 16, 16, 16, 16, 15, 14, 14, 13, 13, 13, 12, -9, -9, -10, -10, -10, -10, -11, -11, -11 };
            Console.WriteLine(CountNegatives(grid));
        }
        static int CountNegatives(int[][] grid)
        {
            int count = 0;
            int cLimit = grid[0].Length;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < cLimit; j++)
                {
                    if (grid[i][j] < 0)
                    {
                        count += (cLimit - j) * (grid.Length - i);
                        cLimit = j;
                        break;
                    }
                }
            }
            return count;
        }
    }
}
