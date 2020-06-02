//使用Linq将words中的单词按出现频率和字母顺序排序。
//将排好序的单词添加到res中，再将末尾的单词删除，直到res的长度为k。
using System;
using System.Collections.Generic;
using System.Linq;

namespace TopKFrequentWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = { "i", "love", "leetcode", "i", "love", "coding" };
            int k = 3;
            Console.WriteLine(TopKFrequent(words, k));
        }
        static IList<string> TopKFrequent(string[] words, int k)
        {
            var record = new Dictionary<string, int>();
            for (int i = 0; i < words.Length; i++)
            {
                if (!record.ContainsKey(words[i]))
                    record[words[i]] = 1;
                else
                    record[words[i]]++;
            }
            int highestFrequency = record.Max(r => r.Value);
            List<string>[] wordCounts = new List<string>[highestFrequency + 1];
            foreach (var kv in record)
            {
                if (wordCounts[kv.Value] == null)
                    wordCounts[kv.Value] = new List<string>() { kv.Key };
                else
                    wordCounts[kv.Value].Add(kv.Key);
            }
            for (int i = 0; i < wordCounts.Length; i++)
                if (wordCounts[i] != null)
                    wordCounts[i] = wordCounts[i].OrderBy(w => w).ToList();
            var res = new List<string>();
            for (int i = wordCounts.Length - 1; i >= 0; i--)
                if (wordCounts[i] != null)
                    foreach (var w in wordCounts[i])
                        res.Add(w);
            while (res.Count > k)
                res.RemoveAt(res.Count - 1);
            return res;
        }
    }
}
