using System;
using System.Collections.Generic;

namespace PrimePairsWithTargetSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var n = 10;
            Console.WriteLine(FindPrimePairs(n));
        }

        public static IList<IList<int>> FindPrimePairs(int n)
        {
            var primes = GetPrimes(n);
            var res = new List<IList<int>>();
            for (int i = 1; i <= n / 2; i++)
            {
                int x = i, y = n - x;
                if (!primes.Contains(x) || !primes.Contains(y)) continue;
                res.Add(new List<int> { x, y });
            }
            return res;
        }

        public static HashSet<int> GetPrimes(int n)
        {
            var dp = new bool[n + 1];
            Array.Fill(dp, true);
            for (int i = 2; i < dp.Length; i++)
            {
                if (!dp[i]) continue;
                for (int j = 2; i * j < dp.Length; j++)
                    dp[i * j] = false;
            }
            var res = new HashSet<int>();
            for (int i = 2; i < dp.Length; i++)
            {
                if (!dp[i]) continue;
                res.Add(i);
            }
            return res;
        }
    }
}
