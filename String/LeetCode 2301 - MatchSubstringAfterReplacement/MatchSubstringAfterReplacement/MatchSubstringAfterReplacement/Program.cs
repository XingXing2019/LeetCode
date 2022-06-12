using System;
using System.Collections.Generic;

namespace MatchSubstringAfterReplacement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s = "fool3e7", sub = "leet";
            char[][] mappings = new[]
            {
                new[] { 'e', '3' },
                new[] { 't', '7' },
                new[] { 't', '8' },
            };
            Console.WriteLine(MatchReplacement(s, sub, mappings));
        }
        public static bool MatchReplacement(string s, string sub, char[][] mappings)
        {
            var dict = new Dictionary<char, HashSet<char>>();
            foreach (var mapping in mappings)
            {
                if (!dict.ContainsKey(mapping[0]))
                    dict[mapping[0]] = new HashSet<char>();
                dict[mapping[0]].Add(mapping[1]);
            }
            var target = s.Substring(0, sub.Length);
            for (int i = 0; i < s.Length - sub.Length; i++)
            {
                if (CanReplace(target, sub, dict))
                    return true;
                target = target.Substring(1) + s[i + sub.Length];
            }
            return CanReplace(target, sub, dict);
        }

        public static bool CanReplace(string target, string sub, Dictionary<char, HashSet<char>> dict)
        {
            for (int i = 0; i < target.Length; i++)
            {
                if (target[i] == sub[i]) continue;
                if (!dict.ContainsKey(sub[i]) || !dict[sub[i]].Contains(target[i]))
                    return false;
            }
            return true;
        }
     }
}
