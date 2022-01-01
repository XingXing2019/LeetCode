// 分治算法
// 遍历nums中的每一个气球，i代表最后要打的那个气球。
// 那么打掉这个气球能得到的分数就是 nums[i] * nums[li - 1] * nums[hi + 1]
// 递归求解i左侧和右侧分别能得到的最大值
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
            return DivideAndConquer(nums, dp, 0, nums.Length - 1);
        }

        public static int DivideAndConquer(int[] nums, int[][] dp, int li, int hi)
        {
            if (li > hi) return 0;
            if (dp[li][hi] != 0) return dp[li][hi];
            var max = nums[li];
            for (int i = li; i <= hi; i++)
            {
                var coins = (li == 0 ? 1 : nums[li - 1]) * nums[i] * (hi == nums.Length - 1 ? 1 : nums[hi + 1]);
                var cur = DivideAndConquer(nums, dp, li, i - 1) + DivideAndConquer(nums, dp, i + 1, hi) + coins;
                max = Math.Max(max, cur);
            }
            dp[li][hi] = max;
            return max;
        }
    }
}
