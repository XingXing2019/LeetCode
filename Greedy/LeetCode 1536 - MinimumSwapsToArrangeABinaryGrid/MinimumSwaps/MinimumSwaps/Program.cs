using System;
using System.Collections.Generic;

namespace MinimumSwaps
{
    class Program
    {
        static void Main(string[] args)
        {
            var grid = new int[][]
            {
                new int[] {0, 0, 1},
                new int[] {1, 1, 0},
                new int[] {1, 0, 0},
            };
            Console.WriteLine(MinSwaps(grid));
        }
        static int MinSwaps(int[][] grid)
        {
            int n = grid.Length;
            var zeroCountIndex = new List<int>[grid.Length];
            for (int i = 0; i < n; i++)
                zeroCountIndex[i] = new List<int>();
            for (int i = 0; i < n; i++)
            {
                int count = 0;
                for (int j = n - 1; j >= 0; j--)
                {
                    if(grid[i][j] != 0)
                        break;
                    count++;
                }
                zeroCountIndex[count].Add(i);
            }
            int swaps = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                n--;
                for (int j = n; j < zeroCountIndex.Length; j++)
                {
                    if (zeroCountIndex[j].Count != 0)
                    {
                        swaps += zeroCountIndex[j][0] - i;
                        zeroCountIndex[j].RemoveAt(0);
                    }
                }
            }
            return swaps;
        }
    }
}
