using System;

namespace FindTheWidthOfColumnsOfAGrid
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int[] FindColumnWidth(int[][] grid)
        {
            var res = new int[grid[0].Length];
            for (int j = 0; j < grid[0].Length; j++)
            {
                var max = 0;
                for (int i = 0; i < grid.Length; i++)
                    max = Math.Max(max, grid[i][j].ToString().Length);
                res[j] = max;
            }
            return res;
        }
    }
}
