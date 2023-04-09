using System;
using System.Collections.Generic;

namespace PrimeInDiagonal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] nums = new int[][]
            {
                new int[] { 1, 2, 3 },
                new int[] { 5, 6, 7 },
                new int[] { 9, 10, 11 },
            };
            Console.WriteLine(DiagonalPrime(nums));
        }

        public static int DiagonalPrime(int[][] nums)
        {
            int n = nums.Length, max = 0, res = 0;
            var diagonals = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                diagonals.Add(nums[i][i]);
                max = Math.Max(max, nums[i][i]);
                diagonals.Add(nums[i][n - i - 1]);
                max = Math.Max(max, nums[i][n - i - 1]);
            }
            var primes = GetPrimes(max);
            foreach (var num in diagonals)
            {
                if (!primes.Contains(num)) continue;
                res = Math.Max(res, num);
            }
            return res;
        }

        private static HashSet<int> GetPrimes(int num)
        {
            var res = new HashSet<int>();
            var dp = new bool[num + 1];
            Array.Fill(dp, true);
            for (int i = 2; i < dp.Length; i++)
            {
                if (!dp[i]) continue;
                for (int j = 2; i * j < dp.Length; j++)
                    dp[i * j] = false;
            }
            for (int i = 2; i < dp.Length; i++)
            {
                if (!dp[i]) continue;
                res.Add(i);
            }
            return res;
        }
    }
}
