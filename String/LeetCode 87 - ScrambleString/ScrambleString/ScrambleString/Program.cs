using System;
using System.Collections.Generic;

namespace ScrambleString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s1 = "abb", s2 = "bba";
            Console.WriteLine(IsScramble(s1, s2));
        }

        public static bool IsScramble(string s1, string s2)
        {
            return DFS(s1, s2, new HashSet<string>());
        }

        public static bool DFS(string s1, string s2, HashSet<string> visited)
        {
            if (s1.Length != s2.Length)
            {
                visited.Add($"{s1}:{s2}");
                return false;
            }
            if (visited.Contains($"{s1}:{s2}")) return false;
            if (s1 == s2) return true;
            for (int i = 1; i < s1.Length; i++)
            {
                var left1 = s1.Substring(0, i);
                var right1 = s1.Substring(i);
                var left2 = s2.Substring(0, i);
                var right2 = s2.Substring(i);
                if (DFS(left1, left2, visited) && DFS(right1, right2, visited))
                    return true;
                if (DFS(left1, right2, visited) && DFS(right1, left2, visited))
                    return true;
                left2 = s2.Substring(0, s2.Length - i);
                right2 = s2.Substring(s2.Length - i);
                if (DFS(left1, left2, visited) && DFS(right1, right2, visited))
                    return true;
                if (DFS(left1, right2, visited) && DFS(right1, left2, visited))
                    return true;
            }
            visited.Add($"{s1}:{s2}");
            return false;
        }
    }
}
