using System;

namespace LongestNonDecreasingSubarray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int MaxNonDecreasingLength(int[] nums1, int[] nums2)
        {
            var dp = new int[nums1.Length][];
            dp[0] = new[] { 1, 1 };
            var res = 1;
            for (int i = 1; i < dp.Length; i++)
            {
                dp[i] = new int[2];
                dp[i][0] = Math.Max(nums1[i] >= nums1[i - 1] ? dp[i - 1][0] + 1 : 1, nums1[i] >= nums2[i - 1] ? dp[i - 1][1] + 1 : 1);
                dp[i][1] = Math.Max(nums2[i] >= nums1[i - 1] ? dp[i - 1][0] + 1 : 1, nums2[i] >= nums2[i - 1] ? dp[i - 1][1] + 1 : 1);
                res = Math.Max(res, Math.Max(dp[i][0], dp[i][1]));
            }
            return res;
        }
    }
}
