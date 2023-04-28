using System;
using System.Collections.Generic;
using System.Linq;

namespace FindMaximalUncoveredRanges
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int[][] FindMaximalUncoveredRanges(int n, int[][] ranges)
        {
            ranges = ranges.OrderBy(x => x[0]).ThenBy(x => x[1]).ToArray();
            int l = 0, r = 0;
            var res = new List<int[]>();
            foreach (var range in ranges)
            {
                if (r < range[0])
                    res.Add(new []{l, range[0] - 1 });
                l = Math.Max(l, range[1] + 1);
                r = Math.Max(r, range[1] + 1);
            }
            if (r < n)
                res.Add(new[] { l, n - 1 });
            return res.ToArray();
        }
    }
}
