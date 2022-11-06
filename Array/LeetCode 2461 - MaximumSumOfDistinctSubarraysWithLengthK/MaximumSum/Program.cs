using System;
using System.Collections.Generic;

namespace MaximumSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 9, 9, 1, 2, 3 };
            Console.WriteLine(MaximumSubarraySum(nums, 3));
        }

        public static long MaximumSubarraySum(int[] nums, int k)
        {
            var prefix = new long[nums.Length];
            for (int i = 0; i < nums.Length; i++)
                prefix[i] = i == 0 ? nums[i] : nums[i] + prefix[i - 1];
            long res = 0;
            var set = new HashSet<int>();
            for (int i = 0; i < k; i++)
                set.Add(nums[i]);
            for (int i = k - 1; i < prefix.Length; i++)
            {
                set.Add(nums[i]);
                set.Add(nums[i - k + 1]);
                if (set.Count == k)
                    res = Math.Max(res, prefix[i] - (i == k - 1 ? 0 : prefix[i - k]));
                set.Remove(nums[i - k + 1]);
            }
            return res;
        }
    }
}
