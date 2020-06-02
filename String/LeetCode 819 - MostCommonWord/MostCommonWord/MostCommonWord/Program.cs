//先将paragraph按照给定的分隔符分割成单个单词，存入字符串数组words。应该注意有可能将空字符串也存入words，因为两个分隔符有可能相连。
//创建records字典，记录单词及其个数。遍历words中的每个单词，如果当前单词不为空，并且不在records字典中，则将其加入字典，并将计数设为1.
//如果当前单词不为空，且已经在records字典中， 则使其在字典中的计数加一。
//遍历banned数组，将其中的单词在字典中去除。
//最后遍历字典，找到出现最多的单词。
using System;
using System.Collections.Generic;

namespace MostCommonWord
{
    class Program
    {
        static void Main(string[] args)
        {
            string paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.";
            string[] banned = { "hit" };
            Console.WriteLine(MostCommonWord(paragraph, banned));
        }
        static string MostCommonWord(string paragraph, string[] banned)
        {
            char[] seperators = new char[] { ' ', '!', '?', '\'', ',', ';', '.'};
            string[] words = paragraph.Split(seperators);
            Dictionary<string, int> records = new Dictionary<string, int>();
            foreach (var word in words)
            {
                if (word != "" && !records.ContainsKey(word.ToLower()))
                    records.Add(word.ToLower(), 1);
                else if (word != "" && records.ContainsKey(word.ToLower()))
                    records[word.ToLower()]++;
            }
            foreach (var word in banned)
                records.Remove(word);
            string res = "";
            int max = 0;
            foreach (var record in records)
            {
                if(record.Value > max)
                {
                    max = record.Value;
                    res = record.Key;
                }
            }
            return res;
        }
    }
}
