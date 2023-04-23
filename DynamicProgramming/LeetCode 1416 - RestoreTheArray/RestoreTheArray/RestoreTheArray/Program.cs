using System;

namespace RestoreTheArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var s = "1317";
            var k = 2000;
            Console.WriteLine(NumberOfArrays(s, k));
        }

        public static int NumberOfArrays(string s, int k)
        {
            long mod = 1_000_000_000 + 7;
            var dp = new long[s.Length + 1];
            Array.Fill(dp, -1);
            return (int)(DFS(s, k, 0, mod, dp) % mod);
        }

        public static long DFS(string s, int k, int index, long mod, long[] dp)
        {
            if (index == s.Length)
                return dp[index] = 1;
            if (s[index] == '0')
                return dp[index] = 0;
            if (dp[index] != -1)
                return dp[index];
            long res = 0;
            for (int i = 1; i <= Math.Min(s.Length - index, 11); i++)
            {
                var num = long.Parse(s.Substring(index, i));
                if (num > k) break;
                res += DFS(s, k, index + i, mod, dp) % mod;
            }
            return dp[index] = res;
        }
    }
}
