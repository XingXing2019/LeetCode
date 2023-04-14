//创建动态数组，dp[i][j]代表以s[i]开头s[j]结尾的字符串回文字的个数。dp[i][i]设为1，代表以s[i]开头和结尾的字符串回文字个数为1。
//动态转移方程为，如果s[i]和s[j]相同，则他们之间回文字的个数dp[i][j]为以s[i + 1]开头s[j - 1]结尾字符串回文字个数加2.
//否则，dp[i][j]为以s[i + 1]开头，以s[j]结尾字符串和以s[i]开头s[j - 1]结尾字符串中回文字多的个数。
using System;

namespace LongestPalindromicSubsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "bbbab";
            Console.WriteLine(LongestPalindromeSubseq(str));
        }
        static int LongestPalindromeSubseq(string s)
        {
            if (s == "")
                return 0;
            int[][] dp = new int[s.Length][];
            for (int i = 0; i < dp.Length; i++)
                dp[i] = new int[s.Length];
            for (int i = s.Length - 1; i >= 0; i--)
            {
                dp[i][i] = 1;
                for (int j = i + 1; j < s.Length; j++)
                {
                    if (s[i] == s[j])
                        dp[i][j] = dp[i + 1][j - 1] + 2;
                    else
                        dp[i][j] = Math.Max(dp[i + 1][j], dp[i][j - 1]);
                }
            }
            return dp[0][s.Length - 1];           
        }
   
    }
}
