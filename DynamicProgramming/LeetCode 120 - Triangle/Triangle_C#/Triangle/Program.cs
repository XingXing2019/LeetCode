//与LeetCode 64思路类似。
//从三角形第二行开始，将三角形的左右两边的各点数字更新为，该点数字与其上面一点的数字之和，因为只有一种方法可以到达该点。
//从第三行开始动态遍历三角形除去左右两边内部的点，将遍历到的点的值更新为该点的值与其上一行相邻点中较小的值之和。
//更新结束后，遍历三角形的下边，找出最小的值即为结果。
using System;
using System.Collections.Generic;

namespace Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] triangle = new int[3][];
            triangle[0] = new int[] { -1 };
            triangle[1] = new int[] { 3, 2 };
            triangle[2] = new int[] { -3, 1, -1 };
            Console.WriteLine(MinimumTotal(triangle));
        }
        static int MinimumTotal(IList<IList<int>> triangle)
        {
            int row = triangle.Count;
            if (row < 2)
                return triangle[0][0];
            for (int r = 1; r < row; r++)
            {
                triangle[r][0] += triangle[r - 1][0];
                triangle[r][r] += triangle[r - 1][r - 1];
            }
            for (int r = 2; r < row; r++)
                for (int c = 1; c < r; c++)
                    triangle[r][c] += Math.Min(triangle[r - 1][c - 1], triangle[r - 1][c]);
            int min = int.MaxValue;
            foreach (var item in triangle[triangle.Count - 1])
                min = Math.Min(min, item);
            return min;
        }
    }
}
