using System;

namespace RemoveAllOnesWithRowAndColumnFlips
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public bool RemoveOnes(int[][] grid)
        {
            for (int r = 0; r < grid.Length; r++)
            {
                if (grid[r][0] == 0) continue;
                for (int c = 0; c < grid[r].Length; c++)
                    grid[r][c] ^= 1;
            }
            for (int c = 0; c < grid[0].Length; c++)
            {
                if (grid[0][c] == 0) continue;
                for (int r = 0; r < grid.Length; r++)
                    grid[r][c] ^= 1;
            }
            for (int r = 0; r < grid.Length; r++)
            {
                for (int c = 0; c < grid[0].Length; c++)
                {
                    if (grid[r][c] == 1)
                        return false;
                }
            }
            return true;
        }
        
    }
}
