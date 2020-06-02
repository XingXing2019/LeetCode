//从第二个坐标开始遍历，计算其与之前一个坐标的距离，优先考虑走对角线，移动到同一行或同一列之后再考虑水平或垂直移动。
using System;

namespace MinimumTimeVisitingAllPoints
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int MinTimeToVisitAllPoints(int[][] points)
        {
            int res = 0;
            for (int i = 1; i < points.Length; i++)
            {
                int v = Math.Abs(points[i][0] - points[i - 1][0]);
                int h = Math.Abs(points[i][1] - points[i - 1][1]);
                res += Math.Min(v, h) + Math.Abs(v - h);
            }
            return res;
        }
    }
}
