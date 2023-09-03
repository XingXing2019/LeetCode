using System;
using System.Collections.Generic;

namespace CountOfInterestingSubarrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var nums = new List<int> { 2, 2, 5, 5 };
            int modulo = 3, k = 2;
            Console.WriteLine(CountInterestingSubarrays(nums, modulo, k));
        }

        public static long CountInterestingSubarrays(IList<int> nums, int modulo, int k)
        {
            var prefix = new int[nums.Count];
            for (int i = 0; i < nums.Count; i++)
            {
                var count = nums[i] % modulo == k ? 1 : 0;
                prefix[i] = i == 0 ? count : count + prefix[i - 1];
            }
            var dict = new Dictionary<int, int> { { 0, 1 } };
            long res = 0;
            foreach (int p in prefix)
            {
                if (dict.ContainsKey((p + modulo - k) % modulo))
                    res += dict[(p + modulo - k) % modulo];
                if (!dict.ContainsKey(p % modulo))
                    dict[p % modulo] = 0;
                dict[p % modulo]++;
            }
            return res;
        }
    }
}
