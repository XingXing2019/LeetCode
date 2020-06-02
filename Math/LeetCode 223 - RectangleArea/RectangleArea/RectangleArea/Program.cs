//计算两个长方形的面积。创建两个bool型检查在水平和垂直方向是否有重合部分。如果没有重合，则返回两个长方形面积之和。
//如果有重合，则计算重合部分，返回面积之和减去重合部分。
using System;

namespace RectangleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            int A = -2, B = -2, C = 2, D = 2, E = -4, F = -4, G = -3, H = -3;
            Console.WriteLine(ComputeArea(A, B, C, D, E, F, G, H));
        }
        static int ComputeArea(int A, int B, int C, int D, int E, int F, int G, int H)
        {
            int area1 = (C - A) * (D - B);
            int area2 = (G - E) * (H - F);
            bool hOverlap = Math.Max(Math.Abs(G - A), Math.Abs(C - E)) < (C - A) + (G - E);
            bool vOverLap = Math.Max(Math.Abs(H - B), Math.Abs(F - D)) < (D - B) + (H - F);
            if (hOverlap && vOverLap)
            {
                int wOverlap = Math.Min(C, G) - Math.Max(A, E);
                int lOverLap = Math.Min(D, H) - Math.Max(B, F);
                return area1 + area2 - wOverlap * lOverLap;
            }
            else
                return area1 + area2;
        }
    }
}
