//用Linq将points按照每个点到原点距离排序，然后将前K个点存入res，并返回。
//耍赖的做法，但是速度打败了99.12%算法。
using System;
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
    }
}
