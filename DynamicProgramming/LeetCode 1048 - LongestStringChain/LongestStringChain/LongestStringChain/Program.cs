//题目要求从words中任意选取符合要求的单词，则不用遵循words原有的顺序。
//创建方法检查是否为predecessor，在出方法中先用linq为words按照单词的长短排序。在创建动态数组dp，代表以每个单词结尾最长链的长度，将dpp[0]设为1。
//从第二个单词开始，依次寻找其与其之前单词能达到的最长链的长度，将这个最大值记录如dp，同时创建一个res记录这个最大值。
//最后返回所记录的最大值。
using System;
using System.Linq;

namespace LongestStringChain
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = { "a", "bca", "ba", "b", "bdca", "bda" };
            Console.WriteLine(LongestStrChain(words));
        }
        static int LongestStrChain(string[] words)
        {
            words = words.OrderBy(w => w.Length).ToArray();
            int[] dp = new int[words.Length];
            dp[0] = 1;
            int res = 0;
            for (int i = 1; i < words.Length; i++)
            {
                int max = 1;
                for (int j = 0; j < i; j++)
                    if (IsPredecessor(words[j], words[i]))
                        max = Math.Max(max, dp[j] + 1);
                dp[i] = max;
                res = Math.Max(res, max);
            }
            return res;
        }
        static bool IsPredecessor(string a, string b)
        {
            if (b.Length - a.Length != 1)
                return false;
            int[] record = new int[26];
            for (int i = 0; i < a.Length; i++)
                record[a[i] - 'a']++;
            for (int i = 0; i < b.Length; i++)
                record[b[i] - 'a']--;
            for (int i = 0; i < record.Length; i++)
                if (record[i] > 0)
                    return false;
            return true;
        }
    }
}
