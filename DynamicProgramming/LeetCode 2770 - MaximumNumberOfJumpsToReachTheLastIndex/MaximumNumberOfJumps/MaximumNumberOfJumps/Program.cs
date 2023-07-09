using System;

namespace MaximumNumberOfJumps
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int MaximumJumps(int[] nums, int target)
        {
            var dp = new int[nums.Length];
            for (int i = 1; i < dp.Length; i++)
            {
                var max = -1;
                for (int j = 0; j < i; j++)
                {
                    if (dp[j] == -1) continue;
                    if (Math.Abs(nums[i] - nums[j]) <= target)
                        max = Math.Max(max, dp[j] + 1);
                }
                dp[i] = max;
            }
            return dp[^1];
        }
    }
}
