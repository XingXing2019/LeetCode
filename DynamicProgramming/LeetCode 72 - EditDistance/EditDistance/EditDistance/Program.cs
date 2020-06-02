/*
           h     ho    hor   hors  horse
    
    r      1     2     2     3     4 

    ro     2     1     2     3     4    

    ros    3     2     2     2     3        
*/

//动态数组中dp[i][j]代表word1中以j结尾的单词变成Word2中以i结尾的单词需要几步。
//如果word1[j]与Word2[i]相同，则dp[i][j]与dp[i-1][j-1]相同。例如hors变成ros，只要考虑怎么把hor变成ro就行。
//如果word1[j]与word2[i]不同，则dp[i][j]为dp[i-1][j-1]，dp[i-1][j]，dp[i][j-1]中最小值加一。例如要把hors变成ro。
//需要考虑怎么把hors变成r(变换后在末尾加o)，hor变成ro(先删掉末尾s再变换)，hor变成r(先变换再在末尾加o)，这三种情况的最小值再加一。
using System;

namespace EditDistance
{
    class Program
    {
        static void Main(string[] args)
        {
            string word1 = "horse";
            string word2 = "ros";
            Console.WriteLine(MinDistance(word1, word2));
        }
        static int MinDistance(string word1, string word2)
        {
            if (word1 == "" || word2 == "")
                return Math.Max(word1.Length, word2.Length);
            var dp = new int[word2.Length][];
            for (int i = 0; i < dp.Length; i++)
                dp[i] = new int[word1.Length];
            dp[0][0] = word1[0] == word2[0] ? 0 : 1;
            for (int i = 1; i < word1.Length; i++)
                dp[0][i] = word1[i] == word2[0] ? i : dp[0][i - 1] + 1;
            for (int i = 1; i < word2.Length; i++)
                dp[i][0] = word1[0] == word2[i] ? i : dp[i - 1][0] + 1;
            for (int i = 1; i < word2.Length; i++)
            {
                for (int j = 1; j < word1.Length; j++)
                {
                    if (word1[j] == word2[i])
                        dp[i][j] = dp[i - 1][j - 1];
                    else
                        dp[i][j] = Math.Min(dp[i - 1][j - 1], Math.Min(dp[i - 1][j], dp[i][j - 1])) + 1;
                }
            }
            return dp[^1][^1];
        }
    }
}
