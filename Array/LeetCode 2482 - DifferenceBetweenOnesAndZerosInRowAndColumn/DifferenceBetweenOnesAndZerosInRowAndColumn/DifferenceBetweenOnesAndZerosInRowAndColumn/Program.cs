using System;
using Microsoft.VisualBasic.CompilerServices;

namespace DifferenceBetweenOnesAndZerosInRowAndColumn
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int[][] OnesMinusZeros(int[][] grid)
        {
            int m = grid.Length, n = grid[0].Length;
            var row = new int[m][];
            var col = new int[n][];
            for (int i = 0; i < m; i++)
            {
                int zero = 0, one = 0;
                for (int j = 0; j < n; j++)
                {
                    zero += grid[i][j] == 0 ? 1 : 0;
                    one += grid[i][j] == 1 ? 1 : 0;
                }
                row[i] = new[] { zero, one };
            }
            for (int j = 0; j < n; j++)
            {
                int zero = 0, one = 0;
                for (int i = 0; i < m; i++)
                {
                    zero += grid[i][j] == 0 ? 1 : 0;
                    one += grid[i][j] == 1 ? 1 : 0;
                }
                col[j] = new[] { zero, one };
            }
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    grid[i][j] = row[i][1] + col[j][1] - row[i][0] - col[j][0];
                }
            }
            return grid;
        }
    }
}
