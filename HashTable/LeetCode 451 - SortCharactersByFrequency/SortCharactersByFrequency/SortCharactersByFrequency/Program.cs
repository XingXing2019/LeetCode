//将字母，和其对应长度的字符串记录如字典。
//使用Linq对字典中的字符串按长度排序并拼入res。
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SortCharactersByFrequency
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "tree";
            Console.WriteLine(FrequencySort2(s));
        }
        static string FrequencySort1(string s)
        {
            string[] strs = new string[128];
            for (int i = 0; i < s.Length; i++)
                strs[s[i]] += s[i];
            var letterFrequency = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (!letterFrequency.ContainsKey(s[i]))
                    letterFrequency[s[i]] = 1;
                else
                    letterFrequency[s[i]]++;
            }
            string[] record = new string[s.Length + 1];
            foreach (var kv in letterFrequency)
                record[kv.Value] += strs[kv.Key];
            string res = "";
            for (int i = record.Length - 1; i >= 0; i--)
                res += record[i];
            return res;
        }
        static string FrequencySort2(string s)
        {
            var dict = new Dictionary<char, StringBuilder>();
            for (int i = 0; i < s.Length; i++)
            {
                if (!dict.ContainsKey(s[i]))
                    dict[s[i]] = new StringBuilder();
                dict[s[i]].Append(s[i]);
            }
            return string.Join("", dict.OrderByDescending(d => d.Value.Length).Select(c => c.Value));
        }

        public string FrequencySort_Linq(string s)
        {
	        var dict = s.GroupBy(x => x).OrderByDescending(x => x.Count()).ToDictionary(x => x.Key, x => x.Count());
	        var res = new StringBuilder();
	        foreach (var item in dict)
		        res.Append(new string(item.Key, item.Value));
	        return res.ToString();
        }
    }
}
