using System;
using System.Collections.Generic;

namespace ShortestDistanceToTargetColor
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] colors = {1, 1, 2, 1, 3, 2, 2, 3, 3};
            int[][] queries = new int[][]
            {
                new int[]{1, 3}, 
                new int[]{2, 2}, 
                new int[]{6, 1}, 
            };
            Console.WriteLine(ShortestDistanceColor(colors, queries));
        }
        static IList<int> ShortestDistanceColor(int[] colors, int[][] queries)
        {
            var res = new List<int>();
            var dict = new Dictionary<int, List<int>>();
            for (int i = 0; i < colors.Length; i++)
            {
                if (!dict.ContainsKey(colors[i]))
                    dict[colors[i]] = new List<int>();
                dict[colors[i]].Add(i);
            }
            foreach (var query in queries)
            {
                if (!dict.ContainsKey(query[1]))
                {
                    res.Add(-1);
                    continue;
                }
                var indeics = dict[query[1]];
                var pos = indeics.BinarySearch(query[0]);
                if (pos < 0) pos = -(pos + 1);
                var min = 0;
                if (pos == 0) 
                    min = indeics[0] - query[0];
                else if (pos == indeics.Count)
                    min = query[0] - indeics[^1];
                else 
                    min = Math.Min(query[0] - indeics[pos - 1], indeics[pos] - query[0]);
                res.Add(min);
            }
            return res;
        }
    }
}
