//创建一个与grid大小相同的二维数组保存结果。
//遍历grid，计算出当前坐标在k次变换后应该在的位置。将当前数字放入res中的该位置。
using System;
using System.Collections.Generic;

namespace Shift2DGrid
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] grid = new int[3][];
            grid[0] = new int[3] { 1, 2, 3 };
            grid[1] = new int[3] { 4, 5, 6 };
            grid[2] = new int[3] { 7, 8, 9 };
            int k = 1;
            Console.WriteLine(ShiftGrid(grid, k));
        }
        static IList<IList<int>> ShiftGrid(int[][] grid, int k)
        {
            int row = grid.Length, col = grid[0].Length;
            int[][] res = new int[row][];
            for (int r = 0; r < row; r++)
                res[r] = new int[col];
            for (int r = 0; r < row; r++)
            {
                for (int c = 0; c < col; c++)
                {
                    int targetRow = (r + (c + k) / col) % row;
                    int targetCol = (c + k) % col;
                    res[targetRow][targetCol] = grid[r][c];
                }
            }
            return res;
        }
    }
}
