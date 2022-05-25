using System;
using System.Linq;

namespace RussianDollEnvelopes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int MaxEnvelopes(int[][] envelopes)
        {
            envelopes = envelopes.OrderBy(x => x[0]).ThenBy(x => x[1]).ToArray();
            var dp = new int[envelopes.Length];
            Array.Fill(dp, 1);
            int res = 0;
            for (int i = 0; i < envelopes.Length; i++)
            {
                for (int j = 0; j < envelopes.Length; j++)
                {
                    if (envelopes[i][0] < envelopes[j][0] && envelopes[i][1] < envelopes[j][1])
                        dp[j] = Math.Max(dp[j], dp[i] + 1);
                }
                res = Math.Max(res, dp[i]);
            }
            return res;
        }
    }
}
