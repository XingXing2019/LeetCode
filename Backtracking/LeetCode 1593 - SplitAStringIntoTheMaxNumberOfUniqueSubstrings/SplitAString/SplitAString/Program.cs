using System;
using System.Collections.Generic;

namespace SplitAString
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = "aa";
            Console.WriteLine(MaxUniqueSplit(s));
        }
        static int MaxUniqueSplit(string s)
        {
            int max = 0;
            DFS(s, 0, new HashSet<string>(), ref max);
            return max;
        }
        static void DFS(string s, int cur, HashSet<string> record, ref int max)
        {
            if (cur == s.Length)
                max = Math.Max(max, record.Count);
            for (int i = 1; i <= s.Length - cur; i++)
            {
                var temp = s.Substring(cur, i);
                if (record.Add(temp))
                {
                    DFS(s, cur + i, record, ref max);
                    record.Remove(temp);
                }
            }
        }
    }
}
