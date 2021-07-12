//创建dict字典，用于记录两个字符串中对应的字母。两个字符串中的字母必须是一一对应。
//遍历字符串，当dict中不存在s[i]时，如果t[i]已经在dict中，证明t[i]对应了多个s中的字母，则返回false。将s[i]和t[i]记入dict字典。
//当dict中存在s[i]时，如果s[i]对应的字母不是t[i]，则证明s[i]对应了多个t中的字母，则返回false。
//遍历结束后但会true。
using System;
using System.Linq;
using System.Collections.Generic;

namespace IsomorphicStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static bool IsIsomorphic(string s, string t)
        {
            Dictionary<char, char> dict = new Dictionary<char, char>();
            for (int i = 0; i < s.Length; i++)
            {
                if (!dict.ContainsKey(s[i]))
                {
                    if (dict.ContainsValue(t[i]))
                        return false;
                    dict[s[i]] = t[i];
                }
                else
                {
                    if (dict[s[i]] != t[i])
                        return false;
                }
            }
            return true;
        }
        public bool IsIsomorphic_Linq(string s, string t)
        {
            var dict = new Dictionary<char, HashSet<char>>();
            var set = new HashSet<char>();
            for (int i = 0; i < s.Length; i++)
            {
                if (!dict.ContainsKey(s[i]))
                {
                    dict[s[i]] = new HashSet<char>();
                    if (!set.Add(t[i])) return false;
                }
                dict[s[i]].Add(t[i]);
            }
            return dict.All(x => x.Value.Count == 1);
        }
    }
}
