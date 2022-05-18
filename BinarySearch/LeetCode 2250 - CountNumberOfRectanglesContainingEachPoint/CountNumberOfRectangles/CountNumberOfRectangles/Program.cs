using System;
using System.Collections.Generic;
using System.Linq;

namespace CountNumberOfRectangles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] rectangles = new[]
            {
                new[] { 1, 2 },
                new[] { 2, 3 },
                new[] { 2, 5 },
            };
            int[][] points = new[]
            {
                new[] { 2, 1 },
                new[] { 1, 4 },
            };
            Console.WriteLine(CountRectangles(rectangles, points));
        }

        public static int[] CountRectangles(int[][] rectangles, int[][] points)
        {
            var max = rectangles.Max(x => x[1]);
            var record = new List<int[]>[max + 1];
            foreach (var r in rectangles)
            {
                if (record[r[1]] == null)
                    record[r[1]] = new List<int[]>();
                record[r[1]].Add(r);
            }
            for (int i = 0; i < record.Length; i++)
            {
                if (record[i] == null) continue;
                record[i] = record[i].OrderBy(x => x[0]).ToList();
            }
            var res = new int[points.Length];
            for (int i = 0; i < points.Length; i++)
            {
                var point = points[i];
                for (int j = point[1]; j < record.Length; j++)
                {
                    if (record[j] == null) continue;
                    res[i] += BinarySearch(record[j], point[0]);
                }
            }
            return res;
        }

        public static int BinarySearch(List<int[]> rectangles, int width)
        {
            int li = 0, hi = rectangles.Count - 1;
            while (li <= hi)
            {
                var mid = li + (hi - li) / 2;
                if (rectangles[mid][0] < width)
                    li = mid + 1;
                else
                    hi = mid - 1;
            }
            return rectangles.Count - li;
        }
    }
}
