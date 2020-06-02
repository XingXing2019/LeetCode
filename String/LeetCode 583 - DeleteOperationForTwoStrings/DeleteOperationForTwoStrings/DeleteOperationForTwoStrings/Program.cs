//应用于LeetCode 1143同样的动态编程思想得到最长的公共子串。
//然后返回word1长度加上word2长度减去二倍的公共子串长度。
using System;

namespace DeleteOperationForTwoStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string word1 = "seadfert";
            string word2 = "eatdfg";
            Console.WriteLine(MinDistance(word1, word2));
        }
        static int MinDistance(string word1, string word2)
        {
            if (word1 == "" || word2 == "")
                return word1.Length + word2.Length;
            int[,] dp = new int[word1.Length, word2.Length];
            if (word1[0] == word2[0])
                dp[0, 0] = 1;
            else
                dp[0, 0] = 0;
            for (int i = 1; i < word2.Length; i++)
            {
                if (word1[0] == word2[i])
                    dp[0, i] = 1;
                else
                    dp[0, i] = dp[0, i - 1];
            }
            for (int i = 1; i < word1.Length; i++)
            {
                if (word1[i] == word2[0])
                    dp[i, 0] = 1;
                else
                    dp[i, 0] = dp[i - 1, 0];
            }
            for (int i = 1; i < word1.Length; i++)
            {
                for (int j = 1; j < word2.Length; j++)
                {
                    if (word1[i] == word2[j])
                        dp[i, j] = dp[i - 1, j - 1] + 1;
                    else
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                }
            }
            return word1.Length + word2.Length - 2 * dp[word1.Length - 1, word2.Length - 1];
        }
    }
}
