//获得两个长方形的长和宽。获取两个长方形在水平方向上最左端点和最右端点。获取在垂直方向的最上端和最下端点。
//检查在水平和垂直方向是否重合，都有重合时返回true。注意要用long型保存数据，否则会有溢出情况。
using System;

namespace RectangleOverlap
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rec1 = { 5, 15, 8, 18 };
            int[] rec2 = { 0, 3, 7, 9 };
            Console.WriteLine(IsRectangleOverlap(rec1, rec2));
        }
        static bool IsRectangleOverlap(int[] rec1, int[] rec2)
        {
            long length1 = Math.Abs(rec1[2] - rec1[0]);
            long height1 = Math.Abs(rec1[3] - rec1[1]);
            long length2 = Math.Abs(rec2[2] - rec2[0]);
            long height2 = Math.Abs(rec2[3] - rec2[1]);

            long hMax = Math.Max(rec1[2], rec2[2]);
            long hMin = Math.Min(rec1[0], rec2[0]);
            bool hOverlap = Math.Abs(hMax - hMin) < (length1 + length2);

            long vMax = Math.Max(rec1[3], rec2[3]);
            long vMin = Math.Min(rec1[1], rec2[1]);
            bool vOverlap = Math.Abs(vMax - vMin) < (height1 + height2);
            return hOverlap && vOverlap;
        }
    }
}
