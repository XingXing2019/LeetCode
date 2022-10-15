using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace RangeProductQueriesOfPowers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var n = 15;
            int[][] queries = new int[][]
            {
                new[] { 0, 1 },
            };
            Console.WriteLine(ProductQueries(n, queries));
        }

        public static int[] ProductQueries(int n, int[][] queries)
        {
            long mod = 1_000_000_000 + 7;
            var powers = new List<long>();
            var num = 1;
            while (num * 2 <= n)
                num *= 2;
            while (n != 0)
            {
                powers.Add(num);
                n -= num;
                while (num > n)
                    num /= 2;
            }

            var sum = powers.Sum();
            powers.Sort();
            var res = new int[queries.Length];
            for (int i = 0; i < queries.Length; i++)
            {
                int start = queries[i][0], end = queries[i][1]; 
                long power = 1;
                for (int j = start; j <= end; j++)
                    power = power * powers[j] % mod;
                res[i] = (int)power;
            }
            return res;
        }
    }
}
