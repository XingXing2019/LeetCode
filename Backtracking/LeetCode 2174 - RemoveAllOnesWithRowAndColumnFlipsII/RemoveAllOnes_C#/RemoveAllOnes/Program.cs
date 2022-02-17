using System;
using System.Linq;

namespace RemoveAllOnes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static int RemoveOnes(int[][] grid)
        {
            if (grid.SelectMany(x => x).All(x => x == 0)) return 0;
            var min = int.MaxValue;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == 0) continue;
                    var copy = CopyArray(grid);
                    foreach (var row in grid) row[j] = 0;
                    Array.Fill(grid[i], 0);
                    min = Math.Min(min, RemoveOnes(grid));
                    grid = copy;
                }
            }
            return min + 1;
        }
        
        private static int[][] CopyArray(int[][] grid)
        {
            var res = new int[grid.Length][];
            for (int i = 0; i < grid.Length; i++)
            {
                res[i] = new int[grid[0].Length];
                Array.Copy(grid[i], res[i], grid[i].Length);
            }
            return res;
        }
    }
}
