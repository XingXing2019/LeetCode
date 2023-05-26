using System;
using System.Linq;

namespace StoneGameII
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] piles = { 2, 7, 9, 4, 4 };
            Console.WriteLine(StoneGameII(piles));
        }

        public static int StoneGameII(int[] piles)
        {
            var dp = new int[piles.Length][];
            for (int i = 0; i < piles.Length; i++)
                dp[i] = new int[piles.Length + 1];
            var diff = DFS(piles, 0, 1, dp);
            return (piles.Sum() + diff) / 2;
        }

        public static int DFS(int[] piles, int index, int M, int[][] dp)
        {
            if (index >= piles.Length)
                return 0;
            if (dp[index][M] != 0)
                return dp[index][M];
            int max = int.MinValue, cur = 0;
            for (int i = index; i < Math.Min(piles.Length, index + 2 * M); i++)
            {
                cur += piles[i];
                max = Math.Max(max, cur - DFS(piles, i + 1, Math.Max(M, i - index + 1), dp));
            }
            return dp[index][M] = max;
        }
    }
}
