using System;

namespace NumberOfZeroFilledSubarrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 3, 0, 0, 2, 0, 0, 4 };
            Console.WriteLine(ZeroFilledSubarray(nums));
        }
        public static long ZeroFilledSubarray(int[] nums)
        {
            long res = 0;
            int li = 0, hi = 0;
            while (hi < nums.Length)
            {
                if (nums[hi] == 0 && nums[li] != 0)
                    li = hi;
                else if (nums[hi] != 0)
                {
                    if (nums[li] == 0)
                        res += (long)(hi - li + 1) * (hi - li) / 2;
                    li = hi;
                }
                hi++;
            }
            if (nums[li] == 0)
                res += (long)(hi - li + 1) * (hi - li) / 2;
            return res;
        }
    }
}
