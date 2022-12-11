using System;

namespace DeleteGreatestValueInEachRow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int DeleteGreatestValue(int[][] grid)
        {
            var res = 0;
            foreach (var row in grid)
                Array.Sort(row);
            for (int j = 0; j < grid[0].Length; j++)
            {
                var max = grid[0][j];
                for (int i = 0; i < grid.Length; i++)
                    max = Math.Max(max, grid[i][j]);
                res += max;
            }
            return res;
        }
    }
}
