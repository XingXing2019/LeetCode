using System;
using System.Collections.Generic;
using System.Linq;

namespace WordPatternII
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = "ab", s = "asas";
            Console.WriteLine(WordPatternMatch(pattern, s));
        }

        private static Dictionary<char, string> letterWordDict;
        private static Dictionary<string, char> wordLetterDict;
        public static bool WordPatternMatch(string pattern, string s)
        {
            letterWordDict = new Dictionary<char, string>();
            wordLetterDict = new Dictionary<string, char>();
            return DFS(pattern, 0, s, 0);
        }

        public static bool DFS(string pattern, int p1, string s, int p2)
        {
            if (p1 == pattern.Length && p2 == s.Length)
                return true;
            if (p1 >= pattern.Length)
                return false;
            var letter = pattern[p1];
            if (letterWordDict.ContainsKey(letter))
            {
                var word = letterWordDict[letter];
                if (p2 + word.Length > s.Length || s.Substring(p2, word.Length) != word) 
                    return false;
                return DFS(pattern, p1 + 1, s, p2 + word.Length);
            }
            for (int i = 1; i <= s.Length - p2; i++)
            {
                var word = s.Substring(p2, i);
                if (wordLetterDict.ContainsKey(word))
                    continue;
                letterWordDict[letter] = word;
                wordLetterDict[word] = letter;
                if (DFS(pattern, p1 + 1, s, p2 + word.Length)) 
                    return true;
                letterWordDict.Remove(letter);
                wordLetterDict.Remove(word);
            }
            return false;
        }
    }
}
