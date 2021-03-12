//创建check布尔型数组，长度设为比s长一位。用于记录在每个字母其后面的字符串是否能被字典中的单词构成，将数组最后一个元素设为true。
//用li指针从字符串最后一个字母向前遍历。创建tem接受临时组成的字符串。
//用hi指针从li指针开始向后遍历，将每次遍历到的字母加入tem。
//只有在tem在字典中，并且在check中hi指针下一个元素为真的情况下(证明hi指针之后的字符串也能被字典中的单词组成)的条件下，将li在check中指向的元素设为true，并终止遍历。
//最后返回check中的第一个结果。
using System;
using System.Collections.Generic;

namespace WordBreak
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "leetcode";
            List<string> wordDict = new List<string>() { "leet", "code" };
            Console.WriteLine(WordBreak(s, wordDict));
        }
        static bool WordBreak(string s, IList<string> wordDict)
        {
            bool[] check = new bool[s.Length + 1];
            check[check.Length - 1] = true;
            for (int li = s.Length - 1; li >= 0; li--)
            {
                string tem = "";
                for (int hi = li; hi < s.Length; hi++)
                {
                    tem += s[hi];
                    if (wordDict.Contains(tem) && check[hi + 1])
                    {
                        check[li] = true;
                        break;
                    }
                }
            }
            return check[0];
        }
    }
}
