using System;

namespace LongestIdealSubsequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int LongestIdealString(string s, int k)
        {
            var dp = new int[26];
            var res = 0;
            foreach (var l in s)
            {
                var max = 0;
                for (int i = 0; i < 26; i++)
                {
                    if (Math.Abs(l - 'a' - i) > k) continue;
                    max = Math.Max(max, dp[i]);
                }
                dp[l - 'a'] = max + 1;
                res = Math.Max(res, dp[l - 'a']);
            }
            return res;
        }
    }
}
