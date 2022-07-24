using System;
using System.Collections.Generic;

namespace EqualRowAndColumnPairs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] grid = new[]
            {
                new int[] { 3, 2, 1 },
                new int[] { 1, 7, 6 },
                new int[] { 2, 7, 7 },
            };
            Console.WriteLine(EqualPairs(grid));
        }

        public static int EqualPairs(int[][] grid)
        {
            var rowDict = new Dictionary<string, int>();
            var colDict = new Dictionary<string, int>();
            for (int r = 0; r < grid.Length; r++)
            {
                var row = "";
                for (int c = 0; c < grid[0].Length; c++)
                    row += $"{grid[r][c]}:";
                rowDict[row] = rowDict.GetValueOrDefault(row, 0) + 1;
            }
            for (int c = 0; c < grid[0].Length; c++)
            {
                var col = "";
                for (int r = 0; r < grid.Length; r++)
                    col += $"{grid[r][c]}:";
                colDict[col] = colDict.GetValueOrDefault(col, 0) + 1;
            }
            var res = 0;
            foreach (var row in rowDict.Keys)
            {
                if (!colDict.ContainsKey(row)) continue;
                res += rowDict[row] * colDict[row];
            }
            return res;
        }
    }
}
