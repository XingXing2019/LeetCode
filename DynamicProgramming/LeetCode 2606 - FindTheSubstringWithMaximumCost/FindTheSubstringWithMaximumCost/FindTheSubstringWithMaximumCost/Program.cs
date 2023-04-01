using System;

namespace FindTheSubstringWithMaximumCost
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var s = "bc";
            var chars = "c";
            int[] vals = { -1 };
            Console.WriteLine(MaximumCostSubstring(s, chars, vals));
        }

        public static int MaximumCostSubstring(string s, string chars, int[] vals)
        {
            var cost = new int[26];
            for (int i = 0; i < 26; i++)
                cost[i] = i + 1;
            for (int i = 0; i < chars.Length; i++)
                cost[chars[i] - 'a'] = vals[i];
            var dp = new int[s.Length];
            dp[0] = cost[s[0] - 'a'];
            var res = Math.Max(0, dp[0]);
            for (int i = 1; i < s.Length; i++)
            {
                dp[i] = Math.Max(dp[i - 1] + cost[s[i] - 'a'], cost[s[i] - 'a']);
                res = Math.Max(res, dp[i]);
            }
            return res;
        }
    }
}
