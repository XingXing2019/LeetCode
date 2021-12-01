
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SubstringWithConcatenationOfAllWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var s = "barfoothefoobarman";
            string[] words = { "foo", "bar" };
            Console.WriteLine(FindSubstring(s, words));
        }
        public static IList<int> FindSubstring(string s, string[] words)
        {
            var res = new List<int>();
            var len = words[0].Length * words.Length;
            if (s.Length < len) return res;
            var dict = words.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
            int li = 0, hi = len - 1;
            var str = new StringBuilder(s.Substring(0, len));
            while (hi < s.Length)
            {
                if (IsValid(str.ToString(), words[0].Length, dict))
                    res.Add(li);
                str.Remove(0, 1);
                if (++hi >= s.Length) break;
                str.Append(s[hi]);
                li++;
            }
            return res;
        }

        public static bool IsValid(string str, int len, Dictionary<string, int> dict)
        {
            var record = new Dictionary<string, int>();
            for (int i = 0; i < str.Length / len; i++)
            {
                var word = str.Substring(i * len, len);
                if (!dict.ContainsKey(word))
                    return false;
                if (!record.ContainsKey(word))
                    record[word] = 0;
                record[word]++;
                if (record[word] > dict[word])
                    return false;
            }
            return true;
        }
    }
}
