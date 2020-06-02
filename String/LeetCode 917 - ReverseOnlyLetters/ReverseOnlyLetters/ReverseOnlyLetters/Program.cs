//创建StringBuilder类型res记录结果，创建signsPos列表记录符号的位置。
//遍历S字符串，如果当前字符为字母，则将其添加到res第一个元素。如果不为字母，则将它的位置记入signsPos。
//完成遍历后的res应为只有字母的S字符串的翻转。遍历一遍signsPos，将S字符串对应位置的符号添加入res中的相应位置。
using System;
using System.Collections.Generic;
using System.Text;

namespace ReverseOnlyLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            string S = "";
            Console.WriteLine(ReverseOnlyLetters(S));
        }
        static string ReverseOnlyLetters(string S)
        {
            StringBuilder res = new StringBuilder();
            List<int> signsPos = new List<int>(); 
            for (int i = 0; i < S.Length; i++)
            {
                if ((S[i] >= 65 && S[i] <= 90) || (S[i] >= 97 && S[i] <= 122))
                    res.Insert(0, S[i]);
                else
                    signsPos.Add(i);
            }
            foreach (var postion in signsPos)
                res.Insert(postion, S[postion]);
            return res.ToString();
        }
    }
}
