using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace TallestBillboard
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] rods = { 1, 2, 3, 4, 5 };
            Console.WriteLine(TallestBillboard(rods));
        }

        public static int TallestBillboard(int[] rods)
        {
            var dp = new Dictionary<int, int>();
            foreach (var rod in rods)
            {
                var cur = new Dictionary<int, int>();
                foreach (var key in dp.Keys)
                    cur[key] = dp[key];
                foreach (var key in cur.Keys)
                {
                    dp[key + rod] = Math.Max(dp.GetValueOrDefault(key + rod, 0), cur[key]);
                    dp[Math.Abs(key - rod)] = Math.Max(dp.GetValueOrDefault(Math.Abs(key - rod), 0), cur[key] + Math.Min(rod, key));
                }
            }
            return dp[0];
        }
    }
}
