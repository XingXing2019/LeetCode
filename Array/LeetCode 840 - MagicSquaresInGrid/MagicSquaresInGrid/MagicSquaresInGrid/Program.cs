using System;
using System.Collections.Generic;
using System.Linq;

namespace MagicSquaresInGrid
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] grid = new int[3][];
            grid[0] = new int[] {4, 3, 8, 4};
            grid[1] = new int[] {9, 5, 1, 9};
            grid[2] = new int[] {2, 7, 6, 2};
            Console.WriteLine(NumMagicSquaresInside(grid));
        }
        static int NumMagicSquaresInside(int[][] grid)
        {
            int res = 0;
            if (grid.Length < 3 || grid[0].Length < 3)
                return res;
            for (int i = 1; i < grid.Length - 1; i++)
            {
                for (int j = 1; j < grid[0].Length-1; j++)
                {
                    int[][] subGrid = new int[3][];
                    subGrid[0] = new int[] {grid[i - 1][j - 1], grid[i - 1][j], grid[i - 1][j + 1]};
                    subGrid[1] = new int[] {grid[i][j - 1], grid[i][j], grid[i][j + 1]};
                    subGrid[2] = new int[] {grid[i + 1][j - 1], grid[i + 1][j], grid[i + 1][j + 1]};
                    if (CheckValid(subGrid))
                        res++;
                }
            }
            return res;
        }
        static bool CheckValid(int[][] subGrid)
        {
            var record = new Dictionary<int, int>{ { 9, 0 }, { 8, 0 }, { 7, 0 }, { 6, 0 }, { 5, 0 }, { 4, 0 }, { 3, 0 }, { 2, 0 }, { 1, 0 } };
            for (int i = 0; i < subGrid.Length; i++)
            {
                for (int j = 0; j < subGrid[0].Length; j++)
                {
                    if (!record.ContainsKey(subGrid[i][j]))
                        return false;
                    else
                    {
                        record[subGrid[i][j]]++;
                        if (record[subGrid[i][j]] > 1)
                            return false;
                    }
                }
            }
            int rowSum = subGrid[0].Sum(n => n);
            for (int i = 1; i < 3; i++)
            {
                int tem = subGrid[i].Sum(n => n);
                if (tem != rowSum)
                    return false;
            }
            for (int j = 0; j < 3; j++)
            {
                int tem = 0;
                for (int i = 0; i < 3; i++)
                    tem += subGrid[i][j];
                if (tem != rowSum)
                    return false;
            }
            if (subGrid[0][0] + subGrid[1][1] + subGrid[2][2] != rowSum ||
                subGrid[0][2] + subGrid[1][1] + subGrid[2][0] != rowSum)
                return false;
            return true;
        }
    }
}
