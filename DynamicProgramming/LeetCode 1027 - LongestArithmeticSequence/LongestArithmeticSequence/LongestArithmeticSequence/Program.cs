using System;
using System.Collections.Generic;

namespace LongestArithmeticSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int LongestArithSeqLength(int[] A)
        {
            var dp = new Dictionary<int, int>[A.Length];
            int res = 0;
            for (int i = 0; i < A.Length; i++)
            {
                dp[i] = new Dictionary<int, int>();
                int max = 0;
                for (int j = 0; j < i; j++)
                {
                    int diff = A[i] - A[j];
                    if (dp[j].ContainsKey(diff))
                        dp[i][diff] = dp[j][diff] + 1;
                    else
                        dp[i][diff] = 2;
                    max = Math.Max(max, dp[i][diff]);
                }
                res = Math.Max(res, max);
            }
            return res;
        }
    }
}
