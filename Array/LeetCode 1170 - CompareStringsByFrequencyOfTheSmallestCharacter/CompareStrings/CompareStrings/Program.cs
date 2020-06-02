//创建CountFrequency方法找到最小字母的出现频率。逻辑为创建映射记录每个字母的频率，在返回最靠前的一个不为零的频率。
//在主方法中创建长度为11的数组wordCount(题目说明queries和words中的单词长度不超过11)，用于记录每个最小字母频率所包含单词的个数。遍历words数组，将每个单词的最小字母频率加入wordCount。
//创建res接收结果，长度设为与queries长度相等。遍历queries中的单词，将其最小字母的频率记录入frequency，创建count用于记录比他最小字母频率高的单词个数。
//在wordCount中，从frequency+1开始遍历，将单词的个数加入count，最后将count记录入res相应位置。
using System;

namespace CompareStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] queries = { "bbb", "cc" };
            string[] words = { "a", "aa", "aaa", "aaaa" };
            Console.WriteLine(NumSmallerByFrequency(queries, words));
        }
        static int[] NumSmallerByFrequency(string[] queries, string[] words)
        {
            int[] wordCount = new int[11];
            for (int i = 0; i < words.Length; i++)
                wordCount[CountFrequency(words[i])]++;
            int[] res = new int[queries.Length];
            for (int i = 0; i < queries.Length; i++)
            {
                int frequency = CountFrequency(queries[i]);
                int count = 0;
                for (int j = frequency + 1; j < wordCount.Length; j++)
                    count += wordCount[j];
                res[i] = count;
            }
            return res;
        }
        static int CountFrequency(string s)
        {
            int res = 0;
            int[] letters = new int[26];
            for (int i = 0; i < s.Length; i++)
                letters[s[i] - 'a']++;
            for (int i = 0; i < letters.Length; i++)
                if (letters[i] != 0)
                {
                    res = letters[i];
                    break;
                }
            return res;
        }
    }
}
