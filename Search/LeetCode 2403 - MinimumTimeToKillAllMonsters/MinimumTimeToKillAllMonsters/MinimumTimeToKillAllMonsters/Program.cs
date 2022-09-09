using System;

namespace MinimumTimeToKillAllMonsters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] power = { 3, 1, 4, 5, 5 };
            Console.WriteLine(MinimumTime(power));
        }

        public static long MinimumTime(int[] power)
        {
            var dp = new long[power.Length + 1][];
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = new long[1 << power.Length];
                Array.Fill(dp[i], long.MaxValue);
            }
            return DFS(power, 1, 0, dp);
        }

        public static long DFS(int[] power, int gain, int mask, long[][] dp)
        {
            if (gain == power.Length + 1) return 0;
            if (dp[gain][mask] != long.MaxValue) return dp[gain][mask];
            var min = long.MaxValue;
            for (int i = 0; i < power.Length; i++)
            {
                if (((mask >> i) & 1) != 0) continue;
                var monster = power[i];
                var temp = (monster + gain - 1) / gain;
                var days = temp + DFS(power, gain + 1, mask | (1 << i), dp);
                min = Math.Min(min, days);
            }
            return dp[gain][mask] = min;
        }
    }
}
