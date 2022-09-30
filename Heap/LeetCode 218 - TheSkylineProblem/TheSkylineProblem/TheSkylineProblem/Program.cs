using System;
using System.Collections.Generic;
using System.Linq;

namespace TheSkylineProblem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var buildings = new int[][]
            {
                new[] { 2, 9, 10 },
                new[] { 3, 7, 15 },
                new[] { 5, 12, 12 },
                new[] { 15, 20, 10 },
                new[] { 19, 24, 8 }
            };
            Console.WriteLine(GetSkyline(buildings));
        }

        public static IList<IList<int>> GetSkyline(int[][] buildings)
        {
            var points = new List<int[]>();
            foreach (var building in buildings)
            {
                points.Add(new[] { building[0], building[2], 1 });
                points.Add(new[] { building[1], building[2], -1 });
            }
            points = points.OrderBy(x => x[0]).ThenByDescending(x => x[1] * x[2]).ToList();
            var list = new SortedList<int, int>();
            var res = new List<IList<int>>();
            foreach (var point in points)
            {
                var height = point[1];
                if (point[2] == 1)
                {
                    if (list.Keys.Count == 0 || height > list.Keys[^1])
                        res.Add(new List<int> { point[0], point[1] });
                    if (!list.ContainsKey(height))
                        list[height] = 0;
                    list[height]++;
                }
                else
                {
                    list[height]--;
                    if (list[height] == 0)
                        list.Remove(height);
                    if (list.Keys.Count == 0 || height > list.Keys[^1])
                        res.Add(new List<int> { point[0], list.Keys.Count == 0 ? 0 : list.Keys[^1] });
                }
            }
            return res;
        }
    }
}
