using System;

namespace MinimumSubarraysInAValidSplit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 89, 1, 829 };
            Console.WriteLine(ValidSubarraySplit(nums));
        }

        public static int ValidSubarraySplit(int[] nums)
        {
            if (nums[0] == 1) return -1;
            var dp = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 1)
                {
                    dp[i] = -1;
                    continue;
                }
                var min = int.MaxValue;
                for (int j = i; j >= 0; j--)
                {
                    if (GCD(nums[i], nums[j]) == 1) continue;
                    min = Math.Min(min, j == 0 ? 1 : dp[j - 1] == -1 ? int.MaxValue : dp[j - 1] + 1);
                }
                dp[i] = min == int.MaxValue ? dp[i - 1] : min;
            }
            return dp[^1];
        }

        public static int GCD(int num1, int num2)
        {
            return num2 == 0 ? num1 : GCD(num2, num1 % num2);
        }
    }
}
