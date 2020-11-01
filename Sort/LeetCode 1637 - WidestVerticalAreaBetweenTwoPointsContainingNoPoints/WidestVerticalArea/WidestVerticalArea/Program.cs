using System;
using System.Linq;

namespace WidestVerticalArea
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int MaxWidthOfVerticalArea(int[][] points)
        {
            points = points.OrderBy(x => x[0]).ToArray();
            var res = 0;
            for (int i = 1; i < points.Length; i++)
                res = Math.Max(res, points[i][0] - points[i - 1][0]);
            return res;
        }
    }
}
