using System;
using System.Linq;

namespace OnesAndZeroes
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] sts = { "0001", "0101", "1000", "1000" };
            int m = 9, n = 3;
            Console.WriteLine(FindMaxForm(sts, m, n));
        }
        public static int FindMaxForm(string[] strs, int m, int n)
        {
            var dp = new int[m + 1][];
            for (int i = 0; i < dp.Length; i++)
                dp[i] = new int[n + 1];
            for (int i = 0; i < strs.Length; i++)
            {
                var zero = strs[i].Count(x => x == '0');
                var one = strs[i].Count(x => x == '1');
                for (int j = m; j >= zero; j--)
                {
                    for (int k = n; k >= one; k--)
                        dp[j][k] = Math.Max(dp[j][k], dp[j - zero][k - one] + 1);
                }
            }
            return dp[^1][^1];
        }
    }
}
