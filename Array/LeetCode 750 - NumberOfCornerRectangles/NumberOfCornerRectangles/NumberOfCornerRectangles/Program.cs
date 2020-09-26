using System;

namespace NumberOfCornerRectangles
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int CountCornerRectangles(int[][] grid)
        {
            int res = 0;
            for (int r1 = 0; r1 < grid.Length; r1++)
            {
                for (int r2 = r1 + 1; r2 < grid.Length; r2++)
                {
                    int count = 0;
                    for (int c = 0; c < grid[0].Length; c++)
                    {
                        if (grid[r1][c] == 1 && grid[r2][c] == 1)
                            count++;
                    }
                    res += count * (count - 1) / 2;
                }
            }
            return res;
        }
    }
}
