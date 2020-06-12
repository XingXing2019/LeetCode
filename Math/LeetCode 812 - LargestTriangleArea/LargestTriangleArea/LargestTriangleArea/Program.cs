//利用叉乘求三角形面积，已知三个点A[x1, y1], B[x2, y2], C[x3, y3]。那面积就是 S=(x1*y2 - x1*y3 + x2*y3 - x2*y1 + x3*y1 - x3*y2) * 0.5
using System;

namespace LargestTriangleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] points = new int[3][]
            {
                new int[]{1,0},
                new int[]{0,0},
                new int[]{0,1},
            };
            Console.WriteLine(LargestTriangleArea(points));
        }
        static double LargestTriangleArea(int[][] points)
        {
            double maxArea = 0;
            for (int i = 0; i < points.Length; i++)
                for (int j = i + 1; j < points.Length; j++)
                    for (int k = j + 1; k < points.Length; k++)
                        maxArea = Math.Max(maxArea, CalcArea(points[i], points[j], points[k]));
            return maxArea;
        }

        static double CalcArea(int[] a, int[] b, int[] c)
        {
            return Math.Abs(a[0] * b[1] - a[0] * c[1] + b[0] * c[1] - b[0] * a[1] + c[0] * a[1] - c[0] * b[1]) * 0.5;
        }
    }
}
