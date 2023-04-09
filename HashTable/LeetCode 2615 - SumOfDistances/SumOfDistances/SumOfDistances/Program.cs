using System;
using System.Collections.Generic;
using System.Linq;

namespace SumOfDistances
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 3, 1, 1, 2 };
            Console.WriteLine(Distance(nums));
        }

        public static long[] Distance(int[] nums)
        {
            var dict = new Dictionary<int, List<int>>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!dict.ContainsKey(nums[i]))
                    dict[nums[i]] = new List<int>();
                dict[nums[i]].Add(i);
            }
            var prefixes = new Dictionary<int, List<long>>();
            foreach (var num in dict.Keys)
            {
                if (prefixes.ContainsKey(num)) continue;
                var prefix = new List<long>();
                for (int i = 0; i < dict[num].Count; i++)
                    prefix.Add(i == 0 ? dict[num][i] : dict[num][i] + prefix[i - 1]);
                prefixes[num] = prefix;
            }
            var res = new long[nums.Length];
            for (int i = 0; i < nums.Length; i++)
                res[i] = GetDistance(dict[nums[i]], prefixes[nums[i]], i);
            return res;
        }

        private static long GetDistance(List<int> indexes, List<long> prefix, int index)
        {
            var pos = indexes.BinarySearch(index);
            long before = pos + 1, after = indexes.Count - before;
            return (index * before - prefix[pos]) + (prefix[^1] - prefix[pos] - index  * after);
        }
    }
}
