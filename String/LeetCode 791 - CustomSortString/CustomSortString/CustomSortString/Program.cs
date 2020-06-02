//创建order字典记录字母在S中的顺序。遍历S，将当前字母和i存入order。创建StringBuilder型res记录结果。将T中第一个字母加入res，并且当其不再order字典中时将其加入order，位置设为-1。
//遍历T，如果当前字母不再order中，则将其加入order，位置设为-1，并将其加入res。最后跳过本次遍历。
//创建j指针，用于指示res中字母的位置。用j遍历res，找到第一个比比当前字母(T[i])在order字典中位置靠后的字母，将当前字母(T[i])插入这个位置，并终止遍历。
//如果遍历后还没有将当前字母插入，这将其插到res最后。
//最后返回res.ToString()。
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomSortString
{
    class Program
    {
        static void Main(string[] args)
        {
            string S = "exv";
            string T = "xwvee";
            Console.WriteLine(CustomSortString(S, T));
        }
        static string CustomSortString(string S, string T)
        {
            if (S == "" || T == "")
                return T;
            Dictionary<char, int> order = new Dictionary<char, int>();
            for (int i = 0; i < S.Length; i++)
                order.Add(S[i], i);
            StringBuilder res = new StringBuilder();
            res.Append(T[0]);
            if (!order.ContainsKey(T[0]))
                order.Add(T[0], -1);
            for (int i = 1; i < T.Length; i++)
            {
                if (!order.ContainsKey(T[i]))
                {
                    order.Add(T[i], -1);
                    res.Append(T[i]);
                    continue;
                }
                int j = 0;
                while (j < res.Length)
                {
                    if (order[T[i]] <= order[res[j]])
                    {
                        res.Insert(j, T[i]);
                        break;
                    }
                    j++;
                }
                if (j == res.Length)
                    res.Append(T[i]);
            }
            return res.ToString();
        }
    }
}
