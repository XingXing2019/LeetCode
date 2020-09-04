using System;
using System.Collections.Generic;

namespace LineReflection
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] points = new[]
            {
                new[] {0, 0},
            };
            Console.WriteLine(IsReflected(points));
        }
        static bool IsReflected(int[][] points)
        {
            var records = new Dictionary<int, List<int>>();
            foreach (var point in points)
            {
                if(!records.ContainsKey(point[1]))
                    records[point[1]] = new List<int>();
                if (!records[point[1]].Contains(point[0]))
                    records[point[1]].Add(point[0]);
            }
            var reflection = new HashSet<double>();
            foreach (var record in records)
            {
                record.Value.Sort();
                int li = 0, hi = record.Value.Count - 1;
                double middlePoint = ((double)record.Value[hi] + record.Value[li]) / 2;
                while (li <= hi)
                {
                    if (((double)record.Value[hi] + record.Value[li]) / 2 != middlePoint)
                        return false;
                    li++;
                    hi--;
                }
                reflection.Add(middlePoint);
            }
            return reflection.Count == 1;
        }
    }
}
