using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace CampusBikes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] workers =
            {
                new[] { 0, 0 },
                new[] { 1, 1 },
                new[] { 2, 0 },
            };
            int[][] bikes =
            {
                new[] { 1, 0 },
                new[] { 2, 2 },
                new[] { 2, 1 },
            };
            Console.WriteLine(AssignBikes(workers, bikes));
        }
        public static int[] AssignBikes(int[][] workers, int[][] bikes)
        {
            var pairs = new int[workers.Length * bikes.Length][];
            var index = 0;
            for (int i = 0; i < workers.Length; i++)
            {
                for (int j = 0; j < bikes.Length; j++)
                {
                    var dis = Math.Abs(workers[i][0] - bikes[j][0]) + Math.Abs(workers[i][1] - bikes[j][1]);
                    pairs[index++] = new[] { dis, i, j };
                }
            }
            pairs = pairs.OrderBy(x => x[0]).ThenBy(x => x[1]).ThenBy(x => x[2]).ToArray();
            var used = new HashSet<int>();
            var res = new int[workers.Length];
            Array.Fill(res, -1);
            foreach (var pair in pairs)
            {
                if (res[pair[1]] != -1 || !used.Add(pair[2])) continue;
                res[pair[1]] = pair[2];
            }
            return res;
        }
    }
}
