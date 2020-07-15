//创建res接收结果，tem临时接收单词。
//从后向前遍历字符串，如果当前元素不为空格，则将其加入tem。如果当前元素为空格，则在tem不为空的情况下将tem和一个空格加入res，并将tem设为空。
//如果i等于0(证明已经遍历到第一个元素)，将此时的tem加入res，最后返回res。
using System;

namespace ReverseWordsInAString
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "a good   example";
            Console.WriteLine(ReverseWords_Manual1(s));
        }
        static string ReverseWords_Manual1(string s)
        {
            string[] words = s.Split(' ');
            string res = "";
            foreach (var word in words)
            {
                if(!string.IsNullOrEmpty(word))
                    res = word + " " + res;
            }
            return res.Trim();
        }
        static string ReverseWords_Manual2(string s)
        {
            string res = "";
            string tem = "";
            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] != ' ')
                    tem = s[i] + tem;
                else
                {
                    if(tem != "")
                    {
                        res += tem + ' ';
                        tem = "";
                    }
                }
                if (i == 0)
                    res += tem;
            }
            return res.Trim();
        }
        static string ReverseWords(string s)
        {
            string[] words = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Array.Reverse(words);
            return string.Join(' ', words);
        }
    }
}
