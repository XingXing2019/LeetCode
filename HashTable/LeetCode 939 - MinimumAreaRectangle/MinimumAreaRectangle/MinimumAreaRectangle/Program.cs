using System;
using System.Collections.Generic;

namespace MinimumAreaRectangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] points = { new[] { 1, 3 }, new[] { 3, 3 }, new[] { 4, 4 }, new[] { 1, 4 } };
            Console.WriteLine(MinAreaRect(points));
        }

        public static int MinAreaRect(int[][] points)
        {
            var horizontal = new Dictionary<int, List<int[]>>();
            var vertical = new Dictionary<int, List<int[]>>();
            var res = int.MaxValue;
            foreach (var point in points)
            {
                int x = point[0], y = point[1];
                if (!horizontal.ContainsKey(x))
                    horizontal[x] = new List<int[]>();
                horizontal[x].Add(point);
                if (!vertical.ContainsKey(y))
                    vertical[y] = new List<int[]>();
                vertical[y].Add(point);
            }
            foreach (var x1 in horizontal.Keys)
            {
                foreach (var point1 in horizontal[x1])
                {
                    var y1 = point1[1];
                    if (!vertical.ContainsKey(y1)) continue;
                    foreach (var point2 in vertical[y1])
                    {
                        if (point1 == point2) continue;
                        var x3 = point2[0];
                        if (!horizontal.ContainsKey(x3)) continue;
                        foreach (var point3 in horizontal[x3])
                        {
                            if (point2 == point3) continue;
                            var y4 = point3[1];
                            if (!vertical.ContainsKey(y4)) continue;
                            foreach (var point4 in vertical[y4])
                            {
                                if (point3 == point4 || point1[0] != point4[0]) continue;
                                res = Math.Min(res, GetArea(point1, point2, point3, point4));
                            }
                        }
                    }
                }
            }
            return res == int.MaxValue ? 0 : res;
        }

        public static int GetArea(int[] point1, int[] point2, int[] point3, int[] point4)
        {
            var l1 = Math.Max(Math.Abs(point1[0] - point2[0]), Math.Abs(point1[1] - point2[1]));
            var l2 = Math.Max(Math.Abs(point2[0] - point3[0]), Math.Abs(point2[1] - point3[1]));
            return l1 * l2;
        }
    }
}
