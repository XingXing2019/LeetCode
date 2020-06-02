//应用动态编程思想，创建二维数组dp。i和j指针分别指向text1和text2中的字母。dp[i,j]代表以i和j结尾的子串中最大相同字母的个数。
//如果text1和text2的首字母相同，则dp[0,0]设为1，否则设为0。遍历二维数组的第一行，如果j指向字母与text1的首字母相同，则将其dp[0,j]设为1，否则设为其前一位的最大数字。
//遍历dp的第一列，做同样操作。
//从i= 1和j=1开始遍历dp数组，如果i和j指向字母相同，则将dp[i,j]设为dp[i-1,j-1]+1，否则就将其设为dp[i-1,j]和dp[i,j-1]中较大的值。
//最后返回dp最右下角的值。
using System;

namespace LongestCommonSubsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            string text1 = "abcde";
            string text2 = "ace";
            Console.WriteLine(LongestCommonSubsequence(text1, text2));
        }
        static int LongestCommonSubsequence(string text1, string text2)
        {
            int[,] dp = new int[text1.Length, text2.Length];
            if (text1[0] == text2[0])
                dp[0, 0] = 1;
            else
                dp[0, 0] = 0;
            for (int i = 1; i < text2.Length; i++)
            {
                if (text1[0] == text2[i])
                    dp[0, i] = 1;
                else
                    dp[0, i] = dp[0, i - 1];
            }
            for (int i = 1; i < text1.Length; i++)
            {
                if (text1[i] == text2[0])
                    dp[i, 0] = 1;
                else
                    dp[i, 0] = dp[i - 1, 0];
            }
            for (int i = 1; i < text1.Length; i++)
            {
                for (int j = 1; j < text2.Length; j++)
                {
                    if (text1[i] == text2[j])
                        dp[i, j] = dp[i - 1, j - 1] + 1;
                    else
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                }
            }
            return dp[text1.Length - 1, text2.Length - 1];
        }
    }
}
