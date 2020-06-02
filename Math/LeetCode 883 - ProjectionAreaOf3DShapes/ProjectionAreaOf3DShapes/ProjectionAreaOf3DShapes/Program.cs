//找到从上往下看每一列的最大值，则其和为第一个面的投影。
//找到从左往右看每一行的最大值，则其和为第二个面的投影。
//之前遍历时顺便记录有几个点为零，则第三个面的投影为行乘以列减去为零的点。
//返回三个面上投影之和。
using System;

namespace ProjectionAreaOf3DShapes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int ProjectionArea(int[][] grid)
        {
            int row = grid.Length, col = grid[0].Length;
            int projection1 = 0;
            int projection2 = 0;
            int countZero = 0;
            for (int r = 0; r < row; r++)
            {
                int max = 0;
                for (int c = 0; c < col; c++)
                {
                    max = Math.Max(max, grid[r][c]);
                    if (grid[r][c] == 0)
                        countZero++;
                }
                projection1 += max;
            }
            for (int c = 0; c < col; c++)
            {
                int max = 0;
                for (int r = 0; r < row; r++)
                    max = Math.Max(max, grid[r][c]);
                projection2 += max;
            }
            int projection3 = row * col - countZero;
            return projection1 + projection2 + projection3;
        }
    }
}
