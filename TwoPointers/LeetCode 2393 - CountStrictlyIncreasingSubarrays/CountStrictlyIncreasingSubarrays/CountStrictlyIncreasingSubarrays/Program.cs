using System;

namespace CountStrictlyIncreasingSubarrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 3, 5, 4, 4, 6 };
            Console.WriteLine(CountSubarrays(nums));
        }

        public static long CountSubarrays(int[] nums)
        {
            int li = 0, hi = 0;
            long res = 0;
            while (hi < nums.Length)
            {
                hi++;
                if (hi >= nums.Length || nums[hi] > nums[hi - 1]) continue;
                res += (long)(hi - li + 1) * (hi - li) / 2;
                li = hi;
            }
            return res + (long)(hi - li + 1) * (hi - li) / 2;
        }
    }
}
