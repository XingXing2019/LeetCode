//用Linq将points按照每个点到原点距离排序，然后将前K个点存入res，并返回。
//耍赖的做法，但是速度打败了99.12%算法。
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace KClosestPointsToOrigin
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] points = new int[3][];
            points[0] = new int[2] { 3, 3 };
            points[1] = new int[2] { 5, -1 };
            points[2] = new int[2] { -2, 4 };
            int K = 2;
            Console.WriteLine(KClosest(points, K));
        }
        static int[][] KClosest(int[][] points, int K)
        {
            var orderedPoints = points.OrderBy(p => p[0] * p[0] + p[1] * p[1]).ToArray();
            int[][] res = new int[K][];
            for (int i = 0; i < res.Length; i++)
                res[i] = orderedPoints[i];
            return res;
        }
        public int[][] KClosest_Linq(int[][] points, int K)
        {
            return points.OrderBy(x => x[0] * x[0] + x[1] * x[1]).Take(K).ToArray();
        }

        public int[][] KClosest_SortedList(int[][] points, int K)
        {
            var list = new SortedList<int, List<int[]>>();
            int count = 0;
            foreach (var point in points)
            {
                if (!list.ContainsKey(point[0] * point[0] + point[1] * point[1]))
                    list[point[0] * point[0] + point[1] * point[1]] = new List<int[]>();
                list[point[0] * point[0] + point[1] * point[1]].Add(point);
                count++;
                if (count > K)
                {
                    list[list.Keys[^1]].RemoveAt(list[list.Keys[^1]].Count - 1);
                    count--;
                    if (list[list.Keys[^1]].Count == 0)
                        list.Remove(list.Keys[^1]);
                }
            }
            var res = new List<int[]>();
            foreach (var kv in list)
                res.AddRange(kv.Value);
            return res.ToArray();
        }
    }
}
