//创建方法检查单词时候符合要求。将S和words中单词中，连续相同的字母归类存在一个列表中。如果两个单词的列表长度不相同，则返回false。
//遍历列表中的每个字母串，如果S列表中字母串的长度小于3，并且S列表中的字母串与word列表中的字母串不相同，则返回false。
//否则，如果S列表中字母串长度小于word列表中的字母串长度，也返回false。
//遍历结束后，仍未返回，则返回true。
//在主方法中遍历words，统计符合要求单词的个数。
using System;
using System.Collections.Generic;

namespace ExpressiveWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string S = "dddiiiinnssssssoooo";
            string word = "ddinso";
            Console.WriteLine(CheckValid(S, word));
        }
        static int ExpressiveWords(string S, string[] words)
        {
            int res = 0;
            foreach (var word in words)
                if (CheckValid(S, word))
                    res++;
            return res;
        }
        static bool CheckValid(string S, string word)
        {
            var sList = GetLetterList(S);
            var wordList = GetLetterList(word);
            if (sList.Count != wordList.Count)
                return false;
            for (int i = 0; i < sList.Count; i++)
            {
                if (sList[i].Length < 3 && sList[i] != wordList[i])
                    return false;
                else if (sList[i].Length < wordList[i].Length)
                    return false;
            }
            return true;
        }
        static List<string> GetLetterList(string s)
        {
            var res = new List<string>();
            if (s.Length == 0)
                return res;
            string tem = s[0].ToString();
            for (int i = 1; i < s.Length; i++)
            {
                if (s[i] == s[i - 1])
                    tem += s[i];
                else
                {
                    res.Add(tem);
                    tem = s[i].ToString();
                }
            }
            res.Add(tem);
            return res;
        }
    }
}
