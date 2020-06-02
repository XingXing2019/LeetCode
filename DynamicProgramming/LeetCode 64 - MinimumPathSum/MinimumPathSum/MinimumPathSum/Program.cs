//思路和LeeCode 62，63类似，使用动态编程思想。到达每个点时的最小值，一定等于那个点的数字加上到达其上面点或其左面点时最小值中较小的一个。
//现将grid，除去左上角的数字，第一排和第一列的数字更新为其当前数字加上其左面或者上面的数字。因为到达第一排和第一列只有一种方法。
//从坐标1，1开始，动态遍历grid，将每个点的数字更新为，该点数字加上其上边或左边两个数字中较小的一个。
//最后返回右下角的数字即为结果。
using System;

namespace MinimumPathSum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int MinPathSum(int[][] grid)
        {
            int row = grid.Length;
            if (row == 0)
                return 0;
            int col = grid[0].Length;
            for (int r = 1; r < row; r++)
                grid[r][0] += grid[r - 1][0];
            for (int c = 1; c < col; c++)
                grid[0][c] += grid[0][c - 1];
            for (int r = 1; r < row; r++)
                for (int c = 1; c < col; c++)
                    grid[r][c] = grid[r][c] + Math.Min(grid[r][c - 1], grid[r - 1][c]);
            return grid[row - 1][col - 1];
        }
    }
}
