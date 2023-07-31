//创建动态二维数组dp，dp[i,j]代表在以i结尾的s1子串和以j结尾的s2子串中，相同字母的ASCII码之和。如果s1和s2第一个字母相同，则dp[0,0]为这个字母的ASCII码，否则dp[0,0]为0.
//遍历dp的第一行，如果s2中当前指针指向的字母与s1首字母相同，则dp[0,i]设为指针在s2中所指字母的ASCII码，否则设为dp[0,i-1]。
//遍历dp的第一列，如果s1中当前指针指向的字母与s2首字母相同，则dp[i,0]设为指针在s1中所指字母的ASCII码，否则设为dp[i-1,0]。
//遍历整个数组，如果i在s1中指向字母与j在s2中指向字母相同，则dp[i,j]设为dp[i-1,j-1]加上当前指向字母的ASCII码，否则设为dp[i-1,j]和dp[i,j-1]中较大的值。遍历结束后可以获得最大公共子串的ASCII码之和。
//遍历s1和s2获得两个字符串所有字母的ASCII码之和。要删去的字母即为所有字母的ASCII码减去两倍的最大公共子串的ASCII码之和。
using System;

namespace MinimumASCIIDeleteSumForTwoStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = "delete";
            string s2 = "leet";
            Console.WriteLine(MinimumDeleteSum(s1, s2));
        }
        static int MinimumDeleteSum(string s1, string s2)
        {
            int[,] dp = new int[s1.Length, s2.Length];
            if (s1[0] == s2[0])
                dp[0, 0] = s1[0];
            else
                dp[0, 0] = 0;
            for (int i = 1; i < s1.Length; i++)
            {
                if (s1[i] == s2[0])
                    dp[i, 0] = s1[i];
                else
                    dp[i, 0] = dp[i - 1, 0];
            }
            for (int i = 1; i < s2.Length; i++)
            {
                if (s2[i] == s1[0])
                    dp[0, i] = s2[i];
                else
                    dp[0, i] = dp[0, i - 1];
            }
            for (int i = 1; i < s1.Length; i++)
            {
                for (int j = 1; j < s2.Length; j++)
                {
                    if (s1[i] == s2[j])
                        dp[i, j] = dp[i - 1, j - 1] + s1[i];
                    else
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                }
            }
            int totalAscii = 0;
            for (int i = 0; i < s1.Length; i++)
                totalAscii += s1[i];
            for (int i = 0; i < s2.Length; i++)
                totalAscii += s2[i];
            return totalAscii - 2* dp[s1.Length - 1, s2.Length - 1];
        }
    }
}
