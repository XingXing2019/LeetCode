using System;
using System.Collections.Generic;

namespace MaximumSumObtainedOfAnyPermutation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 2, 3, 4, 5 };
            int[][] requests = new[]
            {
                new[] { 1, 3 },
                new[] { 0, 1 },
            };
            Console.WriteLine(MaxSumRangeQuery(nums, requests));
        }

        public static int MaxSumRangeQuery(int[] nums, int[][] requests)
        {
            var record = new long[nums.Length];
            foreach (var request in requests)
            {
                record[request[0]]++;
                if (request[1] + 1 < record.Length)
                    record[request[1] + 1]--;
            }
            long freq = 0, mod = 1_000_000_000 + 7, res = 0;
            for (int i = 0; i < record.Length; i++)
            {
                freq += record[i];
                record[i] = freq;
            }
            Array.Sort(record);
            Array.Sort(nums);
            for (int i = 0; i < record.Length; i++)
                res += record[i] * nums[i];
            return (int) (res % mod);
        }
    }
}
