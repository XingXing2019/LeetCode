using System;

namespace WaysToSplitArrayIntoGoodSubarrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 0, 1, 0, 0, 1 };
            Console.WriteLine(NumberOfGoodSubarraySplits(nums));
        }

        public static int NumberOfGoodSubarraySplits(int[] nums)
        {
            var index = Array.IndexOf(nums, 1) + 1;
            if (index == 0) return 0;
            long res = 1, count = 0, mod = 1_000_000_000 + 7;
            while (index < nums.Length)
            {
                count++;
                if (nums[index++] == 1)
                {
                    res = (res * count) % mod;
                    count = 0;
                }
            }
            return (int)(res % mod);
        }
    }
}
