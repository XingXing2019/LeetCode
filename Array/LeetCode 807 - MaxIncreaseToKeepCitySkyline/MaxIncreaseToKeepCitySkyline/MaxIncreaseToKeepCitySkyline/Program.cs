//创建两个数组bottomTop和leftRight分别记录两个方向的skyline。
//遍历grid计算当前行在leftRight中的数字和当前列在bottomTop中数字的最小值与当前遍历到数字只差，将其加入res。
using System;

namespace MaxIncreaseToKeepCitySkyline
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] grid = new int[4][];
            grid[0] = new int[] { 3, 0, 8, 4 };
            grid[1] = new int[] { 2, 4, 5, 7 };
            grid[2] = new int[] { 9, 2, 6, 3 };
            grid[3] = new int[] { 0, 3, 1, 0 };
            Console.WriteLine(MaxIncreaseKeepingSkyline(grid));
        }
        static int MaxIncreaseKeepingSkyline(int[][] grid)
        {
            int row = grid.Length;
            int col = grid[0].Length;
            int[] bottomTop = new int[row];
            int[] leftRight = new int[row];
            for (int i = 0; i < bottomTop.Length; i++)
            {
                int max = 0;
                for (int c = 0; c < col; c++)
                    max = Math.Max(max, grid[i][c]);
                leftRight[i] = max;
            }
            for (int i = 0; i < leftRight.Length; i++)
            {
                int max = 0;
                for (int r = 0; r < row; r++)
                    max = Math.Max(max, grid[r][i]);
                bottomTop[i] = max;
            }
            int res = 0;
            for (int r = 0; r < row; r++)
                for (int c = 0; c < col; c++)
                    res += Math.Min(leftRight[r], bottomTop[c]) - grid[r][c];
            return res;
        }
    }
}
