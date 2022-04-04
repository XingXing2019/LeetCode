using System;

namespace NumberOfDiceRollsWithTargetSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 1, k = 6, target = 3;
            Console.WriteLine(NumRollsToTarget(n, k, target));
        }

        public static int NumRollsToTarget(int n, int k, int target)
        {
            long mod = 1_000_000_000 + 7;
            var dp = new long[n][];
            for (int i = 0; i < n; i++)
                dp[i] = new long[target];
            for (int i = 0; i < Math.Min(k, target); i++)
                dp[0][i] = 1;
            for (int i = 1; i < dp.Length; i++)
            {
                for (int j = 1; j < Math.Min(dp[0].Length, n * k); j++)
                {
                    if (j < i) continue;
                    long sum = 0;
                    for (int l = 0; l < j; l++)
                        sum += dp[i - 1][l] * dp[0][j - l - 1] % mod;
                    dp[i][j] = sum;
                }
            }
            return (int)(dp[^1][^1] % mod);
        }
    }
}
