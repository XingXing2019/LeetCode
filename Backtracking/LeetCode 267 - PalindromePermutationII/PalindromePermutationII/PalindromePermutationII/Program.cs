using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PalindromePermutationII
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public IList<string> GeneratePalindromes(string s)
        {
            var freq = s.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
            var res = new List<string>();
            DFS(freq, new List<char>(), s.Length, res);
            return res;
        }

        public void DFS(Dictionary<char, int> freq, List<char> letters, int count, List<string> res)
        {
            if (count < 2)
            {
                var mid = count == 0 ? "" : freq.Single(x => x.Value == 1).Key.ToString();
                res.Add(Build(letters, mid));
                return;
            }
            foreach (var l in freq.Keys)
            {
                if (freq[l] < 2) continue;
                freq[l] -= 2;
                letters.Add(l);
                DFS(freq, letters, count - 2, res);
                letters.RemoveAt(letters.Count - 1);
                freq[l] += 2;
            }
        }

        public string Build(List<char> letters, string mid)
        {
            StringBuilder left = new StringBuilder(), right = new StringBuilder();
            for (int i = 0; i < letters.Count; i++)
            {
                left.Append(letters[i]);
                right.Append(letters[^(i + 1)]);
            }
            return $"{left}{mid}{right}";
        }
    }
}
