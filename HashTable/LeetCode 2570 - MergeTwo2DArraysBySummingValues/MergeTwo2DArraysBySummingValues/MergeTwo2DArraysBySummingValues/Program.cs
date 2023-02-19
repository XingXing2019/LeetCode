using System;
using System.Collections.Generic;
using System.Linq;

namespace MergeTwo2DArraysBySummingValues
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int[][] MergeArrays(int[][] nums1, int[][] nums2)
        {
            var dict = new Dictionary<int, int>();
            foreach (var num in nums1)
            {
                if (!dict.ContainsKey(num[0]))
                    dict[num[0]] = 0;
                dict[num[0]] += num[1];
            }
            foreach (var num in nums2)
            {
                if (!dict.ContainsKey(num[0]))
                    dict[num[0]] = 0;
                dict[num[0]] += num[1];
            }
            return dict.OrderBy(x => x.Key).Select(x => new int[] {x.Key, x.Value}).ToArray();
        }
    }
}
