//暴力统计，没超时也算是奇迹了。
using System;
using System.Collections.Generic;
using System.Linq;

namespace MaximumNumberOfOccurrencesOfASubstring
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "abcde";
            int maxLetters = 2;
            int minSize = 3;
            int maxSize = 3;
            Console.WriteLine(MaxFreq(s, maxLetters, minSize, maxSize));
        }
        static int MaxFreq(string s, int maxLetters, int minSize, int maxSize)
        {
            var record = new Dictionary<string, int>();
            for (int i = 0; i <= s.Length - minSize; i++)
            {
                for (int j = minSize; j <= maxSize; j++)
                {
                    if (i + j > s.Length)
                        continue;
                    string tem = s.Substring(i, j);
                    if(isValid(tem, maxLetters))
                    {
                        if (!record.ContainsKey(tem))
                            record[tem] = 1;
                        else
                            record[tem]++;
                    }
                }
            }
            if (record.Count == 0)
                return 0;
            return record.Max(r => r.Value);
        }
        static bool isValid(string s, int maxLetters)
        {
            int[] record = new int[26];
            int count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (record[s[i] - 'a'] == 0)
                    count++;
                record[s[i] - 'a']++;
                if (count > maxLetters)
                    return false;
            }
            return true;
        }
    }
}
