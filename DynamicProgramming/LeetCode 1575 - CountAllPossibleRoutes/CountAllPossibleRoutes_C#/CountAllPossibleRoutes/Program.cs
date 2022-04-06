using System;

namespace CountAllPossibleRoutes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] locations = { 4, 3 };
            int start = 1, finish = 0, fuel = 3;
            Console.WriteLine(CountRoutes(locations, start, finish, fuel));
        }

        public static int CountRoutes(int[] locations, int start, int finish, int fuel)
        {
            var dp = new int[locations.Length][];
            var mod = 1_000_000_000 + 7;
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = new int[fuel + 1];
                Array.Fill(dp[i], -1);
            }
            return DFS(locations, start, finish, fuel, mod, dp);
        }

        public static int DFS(int[] locations, int start, int finish, int fuel, int mod, int[][] dp)
        {
            var res = 0;
            if (dp[start][fuel] != -1) return dp[start][fuel];
            if (start == finish) res = (res + 1) % mod;
            for (int i = 0; i < locations.Length; i++)
            {
                var consume = Math.Abs(locations[start] - locations[i]);
                if (i == start || fuel < consume) continue;
                res = (res + DFS(locations, i, finish, fuel - consume, mod, dp)) % mod;
            }
            dp[start][fuel] = res;
            return res;
        }
    }
}
