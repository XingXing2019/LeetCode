//维护一个滑窗，保证滑窗中最多只有一个0.
//当滑窗中0的个数小于2的时候滑动右边界。否则滑动左边界。
//每当0小于等于1的时候就更新最大长度。
using System;
using System.Linq;

namespace LongestSubarray
{
    class Program
    {
        static void Main(string[] args)
        { 
            //             0  1  2  3  4  5  6  7  8  9  10 11
            int[] nums = { 0, 1, 1, 1, 0, 1, 1, 0, 0, 1, 1, 1, 1 };
            Console.WriteLine(LongestSubarray(nums));
        }
        static int LongestSubarray(int[] nums)
        {
            if (nums.All(x => x == 1)) return nums.Length - 1;
            int zero = 0, maxLen = 0, left = 0, right = 0;
            while (right < nums.Length)
            {
                if (zero < 2)
                {
                    if (nums[right] == 0)
                        zero++;
                    right++;
                }
                else
                {
                    if (nums[left] == 0)
                        zero--;
                    left++;
                }
                if (zero <= 1)
                    maxLen = Math.Max(maxLen, right - left - zero);
            }
            return maxLen;
        }
    }
}
