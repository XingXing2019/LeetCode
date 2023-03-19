using System;
using System.Collections.Generic;

namespace SmallestMissingNonNegativeInteger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { -11, 0, 1, 2, -17, -16, -15, -14, 3323 };
            var value = 7;
            Console.WriteLine(FindSmallestInteger(nums, value));
        }

        public static int FindSmallestInteger(int[] nums, int value)
        {
            var freq = new Dictionary<int, int>();
            var lists = new List<int>();
            foreach (var num in nums)
            {
                var mod = num % value;
                if (mod < 0) mod += value;
                if (!freq.ContainsKey(mod))
                    freq[mod] = 0;
                freq[mod]++;
            }
            foreach (var num in freq.Keys)
            {
                var count = freq[num];
                for (int i = 0; i < count; i++)
                    lists.Add(num + value * i);
            }
            lists.Sort();
            for (int i = 0; i < lists.Count; i++)
            {
                if (i == lists[i]) continue;
                return i;
            }
            return lists.Count;
        }
    }
}
