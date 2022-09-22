//先用Trim()将字符串前后的空格去掉。创建res记录结果，创建tem记录临时单词。创建bool型newWord记录是否为新单词。
//遍历字符串，如果当前字符不为空格，则将newWord设为true，并将当前字符加入tem。
//如果当前newWord为true，则在tem后加入一个空格，并将tem加入res，再将tem设为空，最后将newWord设为false。
//遍历结束后，将最后一次的tem加入res。
using System;

namespace ReverseWordsInAStringIII
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = " contest     ";
            Console.WriteLine(ReverseWords2(s));
        }
       
        static string ReverseWords2(string s)
        {
            string S = s.Trim();
            string res = "";
            string tem = "";
            bool newWord = false;
            for (int i = 0; i < S.Length; i++)
            {
                if (S[i] != ' ')
                {
                    newWord = true;
                    tem = S[i] + tem;
                }
                else if(newWord)
                {
                        tem += " ";
                        res += tem;
                        tem = "";
                        newWord = false;
                }
            }
            res += tem;
            return res;
        }
    }
}
