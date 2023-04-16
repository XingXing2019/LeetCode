using System;

namespace NumberOfWays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = { "acca", "bbbb", "caca" };
            var target = "aba";
            Console.WriteLine(NumWays(words, target));
        }

        public static int NumWays(string[] words, string target)
        {
            long mod = 1_000_000_000 + 7;
            int n = target.Length, m = words[0].Length;
            var dp = new long[n + 1][];
            var freq = new int[m + 1][];
            for (int i = 0; i < dp.Length; i++)
                dp[i] = new long[m + 1];
            for (int i = 0; i < freq.Length; i++)
                freq[i] = new int[26];
            foreach (var word in words)
            {
                for (int i = 0; i < m; i++)
                {
                    freq[i + 1][word[i] - 'a']++;
                }
            }
            target = " " + target;
            for (int k = 0; k <= m; k++)
                dp[0][k] = 1;
            for (int i = 1; i <= n; i++)
            {
                for (int k = 1; k <= m; k++)
                {
                    dp[i][k] = dp[i][k - 1] + dp[i - 1][k - 1] * freq[k][target[i] - 'a'] % mod;
                    dp[i][k] %= mod;
                }
            }
            return (int)dp[n][m];
        }
    }
}
