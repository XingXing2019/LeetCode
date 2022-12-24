using System;

namespace DominoAndTrominoTiling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int NumTilings(int n)
        {
            long mod = 1_000_000_000 + 7;
            var dp = new long[n + 1][];
            for (int i = 0; i < dp.Length; i++)
                dp[i] = new long[2];
            dp[0][0] = 1;
            dp[1][0] = 1;
            for (int i = 2; i < dp.Length; i++)
            {
                dp[i][0] = (dp[i - 1][0] + dp[i - 2][0] + 2 * dp[i - 1][1]) % mod;
                dp[i][1] = (dp[i - 2][0] + dp[i - 1][1]) % mod;
            }
            return (int)(dp[^1][0] % mod);
        }
    }
}
