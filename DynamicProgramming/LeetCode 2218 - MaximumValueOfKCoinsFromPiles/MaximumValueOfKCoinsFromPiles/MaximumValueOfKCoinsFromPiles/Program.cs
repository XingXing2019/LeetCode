using System;
using System.Collections.Generic;
using System.Linq;

namespace MaximumValueOfKCoinsFromPiles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<IList<int>> piles = new List<IList<int>>
            {
                new List<int> { 100 },
                new List<int> { 100 },
                new List<int> { 100 },
                new List<int> { 100 },
                new List<int> { 100 },
                new List<int> { 100 },
                new List<int> { 1, 1, 1, 1, 1, 1, 700 },
            };
            var k = 7;
            Console.WriteLine(MaxValueOfCoins(piles, k));
        }


        public static int MaxValueOfCoins(IList<IList<int>> piles, int k)
        {
            var dp = new int[piles.Count + 1][];
            for (int i = 0; i < dp.Length; i++)
                dp[i] = new int[k + 1];
            var totalSize = 0;
            for (int i = 1; i <= piles.Count; i++)
            {
                var size = piles[i - 1].Count;
                totalSize = Math.Min(k, totalSize + size);
                for (int j = 1; j < size; j++)
                    piles[i - 1][j] += piles[i - 1][j - 1];
                for (int j = totalSize; j >= 0; j--)
                {
                    for (int z = -1; z < size; z++)
                    {
                        var val = z == -1 ? 0 : piles[i - 1][z];
                        var count = z + 1;
                        if (j < count) break;
                        dp[i][j] = Math.Max(dp[i][j], dp[i - 1][j - count] + val);
                    }
                }
            }
            return dp[piles.Count][k];
        }
    }
}
