//动态规划，数组中dp[i]代表A[0]到A[i]的子数组能生成的最大值是多少。初始化条件为dp[0]=A[0]，代表如果A中只有一个数字，那么他能生成的最大值就是A[0]。
//状态转移方程可以理解为，以A[0]到A[i-j-1]生成的子数组能获得的最大值，再加上在A[i - j]到A[i]生成的子数组中的最大值乘以子数组数字的个数
//状态转移方程是以i为终点，向前数j(0<=j<k)个数字，其中最大的数字乘以数过数字的个数(j + 1)再加上dp[i - j - 1]的值。那么在这些数字中能形成的最大值就是dp[i].
using System;

namespace PartitionArrayForMaximumSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = {1, 15, 7, 9, 2, 5, 10};
            int K = 3;
            Console.WriteLine(MaxSumAfterPartitioning(A, K));
        }
        static int MaxSumAfterPartitioning(int[] A, int K)
        {
            var dp = new int[A.Length];
            dp[0] = A[0];
            for (int i = 1; i < dp.Length; i++)
            {
                int max = 0;
                for (int j = 0; j < K && i - j >= 0; j++)
                {
                    max = Math.Max(max, A[i - j]);
                    int temp = max * (j + 1);
                    temp += i - j - 1 >= 0 ? dp[i - j - 1] : 0;
                    dp[i] = Math.Max(dp[i], temp);
                }
            }
            return dp[^1];
        }
    }
}
