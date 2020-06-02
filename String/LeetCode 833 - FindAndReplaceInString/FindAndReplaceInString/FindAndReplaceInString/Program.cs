//创建字典record记录需要改写字母的index，source和target。遍历indexes将符合要求的三个参数记录入record。
//创建res记录结果，遍历S如果当前i在record中，则先获取其source的长度len，再将target加入res，然后让i向前移动len-1位。
//如果当前i不在record中，证明无需改写，则将S[i]加入res。
using System;
using System.Text;
using System.Collections.Generic;

namespace FindAndReplaceInString
{
    class Program
    {
        static void Main(string[] args)
        {
            string S = "vmokgggqzp";
            int[] indexes = { 3, 5, 1 };
            string[] sources = { "kg", "ggq", "mo" };
            string[] targets = { "s", "so", "bfr" };
            Console.WriteLine(FindReplaceString(S, indexes, sources, targets));
        }
        static string FindReplaceString(string S, int[] indexes, string[] sources, string[] targets)
        {
            var record = new Dictionary<int, string[]>();
            for (int i = 0; i < indexes.Length; i++)
            {
                int len = sources[i].Length;
                if (S.Substring(indexes[i], len) == sources[i])
                    record[indexes[i]] = new string[2] { sources[i], targets[i] };
            }
            StringBuilder res = new StringBuilder();
            for (int i = 0; i < S.Length; i++)
            {
                if (record.ContainsKey(i))
                {
                    int len = record[i][0].Length;
                    res.Append(record[i][1]);
                    i += len - 1;
                }
                else
                    res.Append(S[i]);
            }
            return res.ToString();
        }
    }
}
