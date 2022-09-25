using System;

namespace LongestSubarrayWithMaximumBitwiseAND
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 2, 3, 3, 2, 2 };
            Console.WriteLine(LongestSubarray(nums));
        }

        public static int LongestSubarray(int[] nums)
        {
            var dp = new int[nums.Length][];
            dp[0] = new int[] { nums[0], 1 };
            int res = 1, max = nums[0];
            for (int i = 1; i < dp.Length; i++)
            {
                if ((nums[i] & dp[i - 1][0]) >= nums[i] && (nums[i] & dp[i - 1][0]) >= dp[i - 1][0])
                    dp[i] = new[] { nums[i] & dp[i - 1][0], dp[i - 1][1] + 1 };
                else
                    dp[i] = new[] { nums[i], 1 };
                if (dp[i][0] > max)
                {
                    res = 1;
                    max = dp[i][0];
                }
                else if (dp[i][0] == max)
                    res = Math.Max(res, dp[i][1]);
            }
            return res;
        }
    }
}
