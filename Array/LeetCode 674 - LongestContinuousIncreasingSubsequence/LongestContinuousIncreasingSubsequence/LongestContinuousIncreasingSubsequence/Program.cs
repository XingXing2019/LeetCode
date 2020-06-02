//滑动窗口找到最长升序数组。
using System;

namespace LongestContinuousIncreasingSubsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 2, 2, 2, 2, 2 };
            Console.WriteLine(FindLengthOfLCIS(nums));
        }
        static int FindLengthOfLCIS(int[] nums)
        {
            if(nums.Length < 2)
                return nums.Length;
            int li = 0, hi = 1;
            int res = 1;
            while (hi < nums.Length)
            {
                if (nums[hi] > nums[hi - 1])
                    res = Math.Max(res, hi - li + 1);
                else
                    li = hi;
                hi++;
            }
            return res;
        }
    }
}
