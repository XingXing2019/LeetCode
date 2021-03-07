using System;
using System.Linq;

namespace FindNearestPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int NearestValidPoint(int x, int y, int[][] points)
        {
            var dict = points.Where(p => p[0] == x || p[1] == y).GroupBy(p => Math.Abs(p[0] - x) + Math.Abs(p[1] - y)).OrderBy(p => p.Key).ToDictionary(p => p.Key, p => p.ToArray());
            if (dict.Count == 0) return -1;
            return Array.IndexOf(points, dict.First().Value.First());
        }
    }
}
