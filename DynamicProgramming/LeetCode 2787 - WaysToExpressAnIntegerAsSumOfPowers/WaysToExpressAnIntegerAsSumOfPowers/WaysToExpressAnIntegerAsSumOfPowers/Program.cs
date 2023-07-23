using System;

namespace WaysToExpressAnIntegerAsSumOfPowers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 4, x = 1;
            Console.WriteLine(NumberOfWays(n, x));
        }

        public static int NumberOfWays(int n, int x)
        {
            long mod = 1_000_000_000 + 7;
            var dp = new long[n + 1][];
            for (int i = 0; i < n; i++)
                dp[i] = new long[n + 1];
            return (int)(DFS(n, 0, 1, x, dp) % mod);
        }

        public static long DFS(long n, long sum, long start, int x, long[][] dp)
        {
            long mod = 1_000_000_000 + 7;
            if (sum >= n)
                return sum == n ? 1 : 0;
            if (dp[sum][start] != 0)
                return dp[sum][start];
            long res = 0;
            for (long i = n - sum; i >= start; i--)
                res += DFS(n, sum + (long)Math.Pow(i, x), i + 1, x, dp) % mod;
            return dp[sum][start] = res % mod;
        }
    }
}
