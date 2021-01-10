using System;
using System.Linq;

namespace TargetSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = {1, 1, 1, 1, 1};
            int S = 3;
            Console.WriteLine(FindTargetSumWays_DP(nums, S));
        }
        static int FindTargetSumWays_DFS(int[] nums, int S)
        {
            var res = 0;
            DFS(nums, S, 0, ref res);
            return res;
        }

        static void DFS(int[] nums, int S, int index, ref int res)
        {
            if (index == nums.Length)
            {
                if (S == 0)
                    res++;
                return;
            }
            DFS(nums, S + nums[index], index + 1, ref res);
            DFS(nums, S - nums[index], index + 1, ref res);
        }

        static int FindTargetSumWays_DP(int[] nums, int S)
        {
            var sum = nums.Sum();
            if (S > sum || S < -sum) return 0;
            var dp = new int[nums.Length + 1][];
            for (int i = 0; i < dp.Length; i++)
                dp[i] = new int[2 * sum + 1];
            dp[0][sum] = 1;
            for (int i = 1; i < dp.Length; i++)
            {
                for (int j = 0; j < dp[i].Length; j++)
                {
                    if (j - nums[i - 1] >= 0)
                        dp[i][j] += dp[i - 1][j - nums[i - 1]];
                    if (j + nums[i - 1] < dp[i].Length)
                        dp[i][j] += dp[i - 1][j + nums[i - 1]];
                }
            }
            return dp[^1][sum + S];
        }
    }
}
