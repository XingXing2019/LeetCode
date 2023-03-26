using System;
using System.Collections.Generic;

namespace MinimumOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 3, 1, 6, 8 }, queries = { 1, 5 };
            Console.WriteLine(MinOperations(nums, queries));
        }

        public static IList<long> MinOperations(int[] nums, int[] queries)
        {
            Array.Sort(nums);
            var res = new long[queries.Length];
            var prefix = new long[nums.Length];
            for (int i = 0; i < nums.Length; i++)
                prefix[i] = i == 0 ? nums[i] : nums[i] + prefix[i - 1];
            for (int i = 0; i < queries.Length; i++)
            {
                var index = Array.BinarySearch(nums, queries[i]);
                if (index < 0) index = ~index;
                var beforeSum = index == 0 ? 0 : prefix[index - 1];
                var beforeCount = index;
                var afterSum = index == 0 ? prefix[^1] : prefix[^1] - prefix[index - 1];
                var afterCount = prefix.Length - index;
                res[i] = (long)queries[i] * beforeCount - beforeSum + afterSum - (long)queries[i] * afterCount;
            }
            return res;
        }
    }
}
