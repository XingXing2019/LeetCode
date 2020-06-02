//创建一个二维数组letterFrequency记录以每个字母为结尾的子字符串中每个字母出现的频率。
//遍历queries，根据letterFrequency中记录的结果获取当前子字符串中每个字母出现的频率。统计其中出现奇数次字母的个数。
//根据个数决定返回true还是false。
using System;
using System.Collections.Generic;

namespace CanMakePalindromeFromSubstring
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "abcda";
            int[][] queries = new int[1][];
            queries[0] = new int[3] { 1, 2, 0 };
            Console.WriteLine(CanMakePaliQueries(s, queries));
        }
        static IList<bool> CanMakePaliQueries(string s, int[][] queries)
        {
            int[] record = new int[26];
            record[s[0] - 'a']++;
            int[][] letterFrequency = new int[s.Length][];
            letterFrequency[0] = record;
            for (int i = 1; i < s.Length; i++)
            {
                int[] tem = new int[26];
                Array.Copy(letterFrequency[i - 1], tem, 26);
                tem[s[i] - 'a']++;
                letterFrequency[i] = tem;
            }
            bool[] res = new bool[queries.Length];
            for (int i = 0; i < queries.Length; i++)
                res[i] = CheckValid(letterFrequency, queries[i][0], queries[i][1], queries[i][2]);
            return res;
        }
        static bool CheckValid(int[][] letterFrequency, int start, int end, int k)
        {
            int[] endRecord = new int[26];
            Array.Copy(letterFrequency[end], endRecord, 26);
            int[] startRecord = new int[26];
            if (start != 0)
                Array.Copy(letterFrequency[start - 1], startRecord, 26);
            for (int i = 0; i < 26; i++)
                endRecord[i] -= startRecord[i];
            int count = 0;
            foreach (var r in endRecord)
                if (r % 2 != 0)
                    count++;
            if (count % 2 == 0)
                return count / 2 <= k;
            else
                return (count - 1) / 2 <= k;
        }
    }
}
