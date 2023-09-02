using System;
using System.Collections.Generic;

namespace ExtraCharactersInAString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var s = "leetscode";
            string[] dictionary = { "leet", "code", "leetcode" };
            Console.WriteLine(MinExtraChar(s, dictionary));
        }

        public static int MinExtraChar(string s, string[] dictionary)
        {
            var words = new HashSet<string>(dictionary);
            var dp = new int[s.Length];
            for (int i = 0; i < dp.Length; i++)
            {
                var min = int.MaxValue;
                for (int j = 0; j <= i; j++)
                {
                    var word = s.Substring(j, i - j + 1);
                    if (!words.Contains(word))
                        min = Math.Min(min, i == 0 ? 1 : dp[i - 1] + 1);
                    else
                        min = Math.Min(min, i - word.Length >= 0 ? dp[i - word.Length] : 0);
                }
                dp[i] = min;
            }
            return dp[^1];
        }
    }
}
