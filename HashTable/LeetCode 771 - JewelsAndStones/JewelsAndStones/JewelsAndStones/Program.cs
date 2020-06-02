//创建字典记录J中的字母，遍历S统计有多少字母在字典中。
using System;
using System.Collections.Generic;

namespace JewelsAndStones
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int NumJewelsInStones(string J, string S)
        {
            var record = new Dictionary<char, int>();
            for (int i = 0; i < J.Length; i++)
                if (!record.ContainsKey(J[i]))
                    record[J[i]] = 1;
            int count = 0;
            for (int i = 0; i < S.Length; i++)
                if (record.ContainsKey(S[i]))
                    count++;
            return count;
        }
    }
}
