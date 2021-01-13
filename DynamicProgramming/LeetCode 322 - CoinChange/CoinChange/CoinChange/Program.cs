using System;

namespace CoinChange
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] coins = {1};
            int amount = 0;
            Console.WriteLine(CoinChange(coins, amount));
        }
        static int CoinChange(int[] coins, int amount)
        {
            var dp = new int[amount + 1];
            for (int i = 1; i < dp.Length; i++)
                dp[i] = -1;
            foreach (var coin in coins)
            {
                if (coin < dp.Length)
                    dp[coin] = 1;
            }
            for (int i = 1; i < dp.Length; i++)
            {
                if (dp[i] == 1) continue;
                var min = int.MaxValue;
                foreach (var coin in coins)
                {
                    if (i - coin < 0 || dp[i - coin] == -1) continue;
                    min = Math.Min(min, dp[i - coin]);
                }
                dp[i] = min == int.MaxValue ? -1 : min + 1;
            }
            return dp[amount];
        }
    }
}
