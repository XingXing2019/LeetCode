//先将数组按照第一个数排序。
//设立left和right代表射击区间，将其初始值设为第一个气球的区间。设置arrows代表射击次数，初始值设为1。
//遍历排序后的数组，如果当前气球的左端点落在射击区间内，减小射击区间，将left设为当前气球的左端点。当气球的右端点也落在设计区间内，则仍需减小射击区间，将right设为当前气球的右端点。
//如果当前气球左端点没有落在射击区间内，则需重新设置射击区间为当前气球的区间。同时射击次数加一。
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace MinimumNumberOfArrowsToBurstBalloons
{
    class Program
    {
        static void Main(string[] args)
        {

        }
        static int FindMinArrowShots(int[][] points)
        {
            if (points.Length < 2)
                return points.Length;
            points = points.OrderBy(p => p[0]).ToArray();
            int right = points[0][1];
            int arrow = 1;
            for (int i = 1; i < points.Length; i++)
            {
                if (points[i][0] <= right)
                    right = Math.Min(right, points[i][1]);
                else
                {
                    arrow++;
                    right = points[i][1];
                }
            }
            return arrow;
        }
    }
}