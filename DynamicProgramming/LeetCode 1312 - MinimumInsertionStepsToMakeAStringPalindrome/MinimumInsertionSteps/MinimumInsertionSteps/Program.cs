using System;

namespace MinimumInsertionSteps
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int MinInsertions(string s)
        {
            var dp = new int[s.Length][];
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = new int[s.Length];
                Array.Fill(dp[i], -1);
            }
            return DFS(s, 0, s.Length - 1, dp);
        }

        public int DFS(string s, int l, int r, int[][] dp)
        {
            if (l >= r)
                return dp[l][r] = 0;
            if (dp[l][r] != -1)
                return dp[l][r];
            if (s[l] == s[r])
                return dp[l][r] = DFS(s, l + 1, r - 1, dp);
            return dp[l][r] =  Math.Min(DFS(s, l + 1, r, dp), DFS(s, l, r - 1, dp)) + 1;
        }
    }
}
