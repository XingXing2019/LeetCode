using System;
using System.Collections.Generic;

namespace LengthOfLongestFibonacciSubsequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 3, 7, 11, 12, 14, 18 };
            Console.WriteLine(LenLongestFibSubseq(arr));
        }

        public static int LenLongestFibSubseq(int[] arr)
        {
            var dp = new Dictionary<int, Dictionary<int, int>>();
            var res = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                dp[arr[i]] = new Dictionary<int, int>();
                if (i < 2) continue;
                for (int j = i - 1; j >= 0 && arr[i] - arr[j] < arr[j]; j--)
                {
                    var candidates = dp[arr[j]];
                    if (candidates.ContainsKey(arr[i] - arr[j]))
                        dp[arr[i]][arr[j]] = candidates[arr[i] - arr[j]] + 1;
                    else if (dp.ContainsKey(arr[i] - arr[j]))
                        dp[arr[i]][arr[j]] = 3;
                    else
                        continue;
                    res = Math.Max(res, dp[arr[i]][arr[j]]);
                }
            }
            return res;
        }
    }
}
