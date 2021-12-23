using System;

namespace DistinctSubsequences
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int NumDistinct(string s, string t)
        {
            var dp = new int[t.Length][];
            for (int i = 0; i < dp.Length; i++)
                dp[i] = new int[s.Length];
            dp[0][0] = s[0] == t[0] ? 1 : 0;
            for (int i = 1; i < s.Length; i++)
                dp[0][i] = t[0] == s[i] ? dp[0][i - 1] + 1 : dp[0][i - 1];
            for (int i = 1; i < dp.Length; i++)
            {
                for (int j = 1; j < dp[0].Length; j++)
                {
                    dp[i][j] = t[i] == s[j] ? dp[i - 1][j - 1] + dp[i][j - 1] : dp[i][j - 1];
                }
            }
            return dp[^1][^1];
        }
    }
}
