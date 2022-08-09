using System;
using System.Collections.Generic;
using System.Linq;

namespace BinaryTreesWithFactors
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 2, 3, 4, 5, 6, 10, 12 };
            Console.WriteLine(NumFactoredBinaryTrees(arr));
        }
        public int NumFactoredBinaryTrees(int[] arr)
        {
            int mod = 1_000_000_000 + 7;
            var dp = new Dictionary<double, long>();
            Array.Sort(arr);
            foreach (var num in arr)
                dp.Add(num, 1);
            long res = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (dp.ContainsKey((double)arr[i] / arr[j]))
                        dp[arr[i]] += dp[arr[j]] * dp[(double)arr[i] / arr[j]];
                }
                res += dp[arr[i]];
            }
            return (int)(res % mod);
        }
    }
}
