using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LexicographicallySmallest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s1 = "parker", s2 = "morris", baseStr = "parser";
            Console.WriteLine(SmallestEquivalentString(s1, s2, baseStr));
        }

        private static Dictionary<char, char> parents;
        public static string SmallestEquivalentString(string s1, string s2, string baseStr)
        {
            parents = new Dictionary<char, char>();
            for (int i = 0; i < 26; i++)
                parents[(char)(i + 'a')] = (char)(i + 'a');
            for (int i = 0; i < s1.Length; i++)
                Union(s1[i], s2[i]);
            var groups = new Dictionary<char, List<char>>();
            foreach (var letter in parents.Keys)
            {
                if (!groups.ContainsKey(parents[letter]))
                    groups[parents[letter]] = new List<char>();
                groups[parents[letter]].Add(Find(letter));
            }
            foreach (var letters in groups.Values)
                letters.Sort();
            var res = new StringBuilder();
            foreach (var letter in baseStr)
            {
                var parent = parents[letter];
                res.Append(!groups.ContainsKey(parent) ? letter : groups[parent][0]);
            }
            return res.ToString();
        }

        public static char Find(char letter)
        {
            if (parents[letter] != letter)
                parents[letter] = Find(parents[letter]);
            return parents[letter];
        }

        public static void Union(char x, char y)
        {
            char rootX = Find(x), rootY = Find(y);
            if (rootX == rootY) return;
            if (rootX < rootY)
                parents[rootY] = rootX;
            else
                parents[rootX] = rootY;
        }
    }
}
