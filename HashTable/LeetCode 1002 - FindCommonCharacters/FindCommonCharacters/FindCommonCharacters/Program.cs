//创建letterFrequency二维数组记录每个单词中每个字母出现的频率。
//遍历A，统计每个单词中每个字母出现的频率，记录在一个长度为26的数组中，并将其计入letterFrequency。
//创建record数组，统计每个字母出现的最小频率。将其初始值全部设为101(因为A中每个单词最长为100)。
//遍历letterFrequency，统计每个字母出现的最小频率，将其计入record。
//遍历record，将每个字母重复其最小频率次，记入res。
using System;
using System.Collections.Generic;

namespace FindCommonCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] A = { "bella", "label", "roller" };
            Console.WriteLine(CommonChars(A));
        }
        static IList<string> CommonChars(string[] A)
        {
            int[][] letterFrequency = new int[A.Length][];
            for (int i = 0; i < A.Length; i++)
            {
                int[] letters = new int[26];
                foreach (var l in A[i])
                    letters[l - 'a']++;
                letterFrequency[i] = letters;
            }
            int[] record = new int[26];
            for (int i = 0; i < 26; i++)
                record[i] = 101;

            List<string> res = new List<string>();

            for (int i = 0; i < letterFrequency.Length; i++)
                for (int j = 0; j < 26; j++)
                    record[j] = Math.Min(record[j], letterFrequency[i][j]);

            for (int i = 0; i < record.Length; i++)
                for (int j = 0; j < record[i]; j++)
                    res.Add(((char)(i + 97)).ToString());
            return res;
        }
    }
}
