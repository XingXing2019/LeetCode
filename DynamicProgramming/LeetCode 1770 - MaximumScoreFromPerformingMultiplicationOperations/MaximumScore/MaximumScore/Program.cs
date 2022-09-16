using System;

namespace MaximumScore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 18, 4, -5, -4 };
            int[] multipliers = { 3, 46, -25 };
            Console.WriteLine(MaximumScore(nums, multipliers));
        }

        public static int MaximumScore(int[] nums, int[] multipliers)
        {
            var dp = new int[multipliers.Length][];
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = new int[multipliers.Length];
                Array.Fill(dp[i], int.MaxValue);
            }
            return DFS(nums, multipliers, 0, nums.Length - 1, 0, dp);
        }

        public static int DFS(int[] nums, int[] multipliers, int i, int j, int m, int[][] dp)
        {
            if (m == multipliers.Length)
                return 0;
            if (dp[i][m] != int.MaxValue)
                return dp[i][m];
            var left = nums[i] * multipliers[m] + DFS(nums, multipliers, i + 1, j, m + 1, dp);
            var right = nums[j] * multipliers[m] + DFS(nums, multipliers, i, j - 1, m + 1, dp);
            return dp[i][m] = Math.Max(left, right);
        }
    }
}
