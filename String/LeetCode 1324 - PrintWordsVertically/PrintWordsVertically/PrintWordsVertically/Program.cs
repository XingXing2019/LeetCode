//将s按照空格分成单词。找到最长的单词的长度max。
//在max的范围内循环操作，如果当前i不大于当前单词的长度，则将对应字母接入tem，否则将空格加入tem。
//找到前面有多少空格，将其与trim后的tem加入res。
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrintWordsVertically
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "DHGDH DFGHFH GHJ EW GHMK S FJASG G SNDHFM CF";
            Console.WriteLine(PrintVertically(s));
        }
        static IList<string> PrintVertically(string s)
        {
            string[] words = s.Split(" ");
            int max = words.Max(w => w.Length);
            List<string> res = new List<string>();
            for (int i = 0; i < max; i++)
            {
                string tem = "";
                foreach (var w in words)
                {
                    if (i < w.Length)
                        tem += w[i];
                    else
                        tem += " ";
                }
                string frontSpace = "";
                for (int j = 0; j < tem.Length; j++)
                {
                    if (tem[j] == ' ')
                        frontSpace += " ";
                    else
                        break;
                }
                res.Add(frontSpace + tem.Trim());
            }
            return res;
        }
    }
}
