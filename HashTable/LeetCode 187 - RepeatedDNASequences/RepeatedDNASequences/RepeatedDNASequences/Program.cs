//创建hashMap字典，key设为string，value设为int，用于保存长度为10的DNA片段，及其相应的个数。
//在0到s.Length-10(包括)范围内遍历字符串s，设置word代表DNA片段，其开始位为i，长度为10.
//如果word不在hashMap字典中，则将word和1加入字典。
//如果word在字典中，则使其对应的value加一。
//设置List<string>保存res，遍历字典把所有value大于1的key加入res。
using System;
using System.Collections.Generic;

namespace RepeatedDNASequences
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "AAAAAAAAAAA";
            FindRepeatedDnaSequences(s);
        }
        static IList<string> FindRepeatedDnaSequences(string s)
        {
            var hashMap = new Dictionary<string, int>();
            for (int i = 0; i <= s.Length - 10; i++)
            {
                string word = s.Substring(i, 10);
                if (!hashMap.ContainsKey(word))
                    hashMap.Add(word, 1);
                else
                    hashMap[word]++;
            }
            List<string> res = new List<string>();
            foreach (var kvPair in hashMap)
                if (kvPair.Value > 1)
                    res.Add(kvPair.Key);
            return res;
        }
    }
}
