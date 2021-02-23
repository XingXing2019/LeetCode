//创建CheckMatch方法，用双指针发检查一个字符串是否能通过删减字母的方法构成另一个字符串。
//在主方法中创建res接收结果。对于d中的每一个单词调用CheckMatch方法，如果返回值为true，则当当前单词长度大于res长度时，用当前单词替换res。如果当前单词长度与res相同，则比较他们第一个字母的排位，如果当前单词排位靠前，则用其替换res。
using System;
using System.Collections.Generic;

namespace LongestWordInDictionaryThroughDeleting
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "applee";
            string[] d = { "b", "a", "c" };
            Console.WriteLine(FindLongestWord(s, d));
        }
        static string FindLongestWord(string s, IList<string> d)
        {
            string res = "";
            foreach (var word in d)
            {
                if(CheckMatch(word, s))
                {
                    if (word.Length > res.Length)
                        res = word;
                    else if(word.Length == res.Length)
                    {
                        if(word[0] < res[0])
                            res = word;
                    }
                }
            }
            return res;
        }
        static bool CheckMatch(string pattern, string word)
        {
            int p1 = 0;
            int p2 = 0;
            while (p1 < pattern.Length && p2 < word.Length)
            {
                if (pattern[p1] == word[p2])
                {
                    p1++;
                    p2++;
                }
                else
                    p2++;
            }
            return p1 >= pattern.Length;
        }
    }
}
