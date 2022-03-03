using System;

namespace NumberOfWays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var n = 16;
            Console.WriteLine(HouseOfCards(n));
        }

        public static int HouseOfCards(int n)
        {
            var dp = new int[n + 1][];
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = new int[n + 1];
                Array.Fill(dp[i], -1);
            }
            return DFS(n, (n + 1) / 3, dp);
        }

        public static int DFS(int n, int limit, int[][] dp)
        {
            if (n == 0) return 1;
            if (n < 0) return 0;
            if (dp[n][limit] != -1) return dp[n][limit];
            var res = 0;
            for (int i = 1; i <= limit; i++)
            {
                var used = i * 3 - 1;
                res += DFS(n - used, i - 1, dp);   
            }
            dp[n][limit] = res;
            return res;
        }
    }
}
