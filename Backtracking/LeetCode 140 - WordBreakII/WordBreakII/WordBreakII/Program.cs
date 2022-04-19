using System;
using System.Collections.Generic;

namespace WordBreakII
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public IList<string> WordBreak(string s, IList<string> wordDict)
        {
            var res = new List<string>();
            DFS(s, "", new HashSet<string>(wordDict), res);
            return res;
        }

        public void DFS(string s, string cur, HashSet<string> wordDict, List<string> res)
        {
            if (s.Length == 0)
                res.Add(cur.Trim());
            for (int i = 1; i <= s.Length; i++)
            {
                var word = s.Substring(0, i);
                if (!wordDict.Contains(word)) continue;
                DFS(s.Substring(i), $"{cur} {word}", wordDict, res);
            }
        }
    }
}
