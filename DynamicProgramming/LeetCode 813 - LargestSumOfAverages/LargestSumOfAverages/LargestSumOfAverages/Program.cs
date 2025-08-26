using System;

namespace LargestSumOfAverages
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = { 9, 1, 2, 3, 9 };
            int K = 3;
            Console.WriteLine(LargestSumOfAverages(A, K));
        }
        public static double LargestSumOfAverages(int[] nums, int k)
        {
            var prefix = new double[nums.Length];
            for (int i = 0; i < nums.Length; i++)
                prefix[i] = i == 0 ? nums[i] : nums[i] + prefix[i - 1];
            var dp = new double[k][];
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = new double[nums.Length];
                Array.Fill(dp[i], -1);
            }
            for (int i = 0; i < nums.Length; i++)
                dp[0][i] = prefix[i] / (i + 1);
            for (int x = 1; x < dp.Length; x++)
            {
                for (int y = x; y < dp[x].Length; y++)
                {
                    var max = 0d;
                    for (int z = 0; z < y; z++)
                    {
                        var temp = dp[x - 1][z];
                        if (temp == -1) continue;
                        var avg = (prefix[y] - prefix[z]) / (y - z);
                        max = Math.Max(max, temp + avg);
                    }
                    dp[x][y] = max;
                }
            }
            return dp[^1][^1];
        }
    }
}
