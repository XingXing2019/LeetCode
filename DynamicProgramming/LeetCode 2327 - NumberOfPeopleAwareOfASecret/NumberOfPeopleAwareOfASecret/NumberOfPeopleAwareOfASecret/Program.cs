using System;

namespace NumberOfPeopleAwareOfASecret
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int PeopleAwareOfSecret(int n, int delay, int forget)
        {
            var dp = new long[n + 1];
            dp[1] = 1;
            long share = 0, res = 0, mod = 1_000_000_000 + 7;
            for (int i = 2; i < dp.Length; i++)
            {
                share += i - delay >= 0 ? dp[i - delay] : 0;
                share -= i - forget >= 0 ? dp[i - forget] : 0;
                dp[i] = share % mod;
            }
            for (int i = n - forget + 1; i < dp.Length; i++)
                res = (res + dp[i]) % mod;
            return (int) (res % mod);
        }
    }
}
