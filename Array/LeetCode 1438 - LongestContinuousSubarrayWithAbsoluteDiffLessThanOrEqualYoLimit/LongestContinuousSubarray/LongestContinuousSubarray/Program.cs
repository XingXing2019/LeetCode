using System;

namespace LongestContinuousSubarray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 24, 12, 71, 33, 5, 87, 10, 11, 3, 58, 2, 97, 97, 36, 32, 35, 15, 80, 24 };
            int limit = 87;
            Console.WriteLine(LongestSubarray(nums, limit));

        }
        static int LongestSubarray(int[] nums, int limit)
        {
            int li = 0, hi = 0;
            int max = 0, min = int.MaxValue;
            int longest = 0;
            while (hi < nums.Length)
            {
                if (max - min <= limit)
                {
                    max = Math.Max(max, nums[hi]);
                    min = Math.Min(min, nums[hi]);
                    hi++;
                    longest = max - min <= limit? Math.Max(longest, hi - li) : longest;
                }
                else
                {
                    while (li < hi && max - min > limit)
                    {
                        li++;
                        max = 0;
                        min = int.MaxValue;
                        for (int i = li; i <= hi; i++)
                        {
                            max = Math.Max(max, nums[i]);
                            min = Math.Min(min, nums[i]);
                        }
                    }
                    longest = Math.Max(longest, hi - li + 1);
                }
            }
            return longest;
        }
    }
}
