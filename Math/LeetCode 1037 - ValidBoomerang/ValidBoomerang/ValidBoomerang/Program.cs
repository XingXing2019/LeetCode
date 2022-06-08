﻿//如果三个点没有重复，且两两之间斜率不相等，返回true，否则返回false
using System;
using System.Collections.Generic;
using System.Linq;

namespace ValidBoomerang
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] points = new int[3][];
            points[0] = new int[] { 0, 1 };
            points[1] = new int[] { 1, 1 };
            points[2] = new int[] { 2, 1 };
            Console.WriteLine(IsBoomerang_Math(points));
        }
        static bool IsBoomerang(int[][] points)
        {
            points = points.OrderBy(p => p[0]).ToArray();
            for (int i = 0; i < points.Length; i++)
                for (int j = i + 1; j < points.Length; j++)
                    if (points[i][0] == points[j][0] && points[i][1] == points[j][1])
                        return false;
            double slope = (double)(points[0][0] - points[1][0]) / (double)(points[0][1] - points[1][1]);
            for (int i = 0; i < points.Length; i++)
            {
                for (int j = i + 1; j < points.Length; j++)
                {
                    if (i == 0 && j == 1)
                        continue;
                    if ((double)(points[i][0] - points[j][0]) / (double)(points[i][1] - points[j][1]) == slope)
                        return false;
                }
            }      
            return true;
        }

        static bool IsBoomerang_Math(int[][] points)
        {
            var set = new HashSet<string>(points.Select(x => $"{x[0]}:{x[1]}"));
            if (set.Count != 3) return false;
            var slop1 = ((double)points[0][0] - points[1][0]) / (points[0][1] - points[1][1]);
            var slop2 = ((double)points[1][0] - points[2][0]) / (points[1][1] - points[2][1]);
            var slop3 = ((double)points[2][0] - points[0][0]) / (points[2][1] - points[0][1]);
            var infinity = double.PositiveInfinity;
            return (slop1 != slop2 || slop2 != slop3) && (Math.Abs(slop1) != infinity || Math.Abs(slop2) != infinity || Math.Abs(slop3) != infinity);
        }
    }
}
