using System;

namespace BurstBalloons
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 3, 1, 5 };
            Console.WriteLine(MaxCoins(nums));
        }

        public static int MaxCoins(int[] nums)
        {
            var dp = new int[nums.Length][];
            for (int i = 0; i < nums.Length; i++)
                dp[i] = new int[nums.Length];
            return DFS(nums, dp, 0, nums.Length - 1);
        }

        public static int DFS(int[] nums, int[][] dp, int li, int hi)
        {
            if (li > hi) return 0;
            if (dp[li][hi] != 0) return dp[li][hi];
            var max = nums[li];
            for (int i = li; i <= hi; i++)
            {
                var coins = (li == 0 ? 1 : nums[li - 1]) * nums[i] * (hi == nums.Length - 1 ? 1 : nums[hi + 1]);
                var cur = DFS(nums, dp, li, i - 1) + DFS(nums, dp, i + 1, hi) + coins;
                max = Math.Max(max, cur);
            }
            dp[li][hi] = max;
            return max;
        }
    }
}
