using System;

namespace CheckIfThereIsAValidPartition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public bool ValidPartition(int[] nums)
        {
            var dp = new bool[nums.Length];
            dp[1] = nums[0] == nums[1];
            for (int i = 2; i < dp.Length; i++)
            {
                if (nums[i] == nums[i - 1] && dp[i - 2])
                    dp[i] = true;
                else if (nums[i] == nums[i - 1] && nums[i] == nums[i - 2] && (i == 2 || dp[i - 3]))
                    dp[i] = true;
                else if (nums[i] == nums[i - 1] + 1 && nums[i] == nums[i - 2] + 2 && (i == 2 || dp[i - 3]))
                    dp[i] = true;
                else if (nums[i] == nums[i - 1] - 1 && nums[i] == nums[i - 2] - 2 && (i == 2 || dp[i - 3]))
                    dp[i] = true;
            }
            return dp[^1];
        }
    }
}
