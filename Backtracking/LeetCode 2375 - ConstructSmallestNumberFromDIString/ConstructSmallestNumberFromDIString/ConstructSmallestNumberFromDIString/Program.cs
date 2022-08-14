using System;
using System.Collections.Generic;

namespace ConstructSmallestNumberFromDIString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var pattern = "IIIDIDDD";
            Console.WriteLine(SmallestNumber(pattern));
        }
        
        public static string SmallestNumber(string pattern)
        {
            var res = new string('9', pattern.Length + 1);
            for (int i = 1; i <= 9; i++)
                DFS(pattern, i.ToString(), new HashSet<int>{i}, ref res);
            return res;
        }

        public static void DFS(string pattern, string cur, HashSet<int> visited, ref string res)
        {
            if (cur.Length == pattern.Length + 1)
            {
                if (cur.CompareTo(res) < 0)
                    res = cur;
                return;
            }
            for (int i = 1; i <= 9; i++)
            {
                if (visited.Contains(i))
                    continue;
                if (cur.Length != 0 && pattern[cur.Length - 1] == 'I' && i < cur[^1] - '0')
                    continue;
                if (cur.Length != 0 && pattern[cur.Length - 1] == 'D' && i > cur[^1] - '0')
                    continue;
                visited.Add(i);
                DFS(pattern, cur + i, visited, ref res);
                visited.Remove(i);
            }
        }
    }
}
