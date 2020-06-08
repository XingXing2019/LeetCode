//对于每一个不为0的格子，先将它底面顶面和四个侧面的面积加入结果。
//如果与他相邻的格子也有柱子，则将较短柱子重叠侧面的两倍从结果中减去。
using System;

namespace SurfaceAreaOf3DShapes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int SurfaceArea(int[][] grid)
        {
            int area = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] > 0) area += 4 * grid[i][j] + 2;
                    if (i > 0) area -= Math.Min(grid[i][j], grid[i - 1][j]) * 2;
                    if (j > 0) area -= Math.Min(grid[i][j], grid[i][j - 1]) * 2;
                }
            }
            return area;
        }
    }
}
