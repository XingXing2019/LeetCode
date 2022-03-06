using System;

namespace CountAllValid
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }
        public int CountOrders(int n)
        {
            var dp = new long[n];
            dp[0] = 1;
            long mod = 1_000_000_000 + 7, start = 3;
            for (int i = 1; i < n; i++)
            {
                long sum = (1 + start) * start / 2;
                dp[i] = dp[i - 1] * sum % mod;
                start += 2;
            }
            return (int)(dp[^1] % mod);
        }
    }
}
