using System;
using System.Collections.Generic;

namespace CountSubstrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "abe", t = "bbc";
            Console.WriteLine(CountSubstrings(s, t));
        }
        static int CountSubstrings(string s, string t)
        {
            var dict = new Dictionary<int, List<string>>();
            for (int i = 1; i <= t.Length && i <= s.Length; i++)
            {
                dict[i] = new List<string>();
                for (int j = 0; j <= t.Length - i; j++)
                    dict[i].Add(t.Substring(j, i));
            }
            var res = 0;
            for (int i = 1; i <= s.Length && i <= t.Length; i++)
            {
                for (int j = 0; j <= s.Length - i; j++)
                {
                    var temp = s.Substring(j, i);
                    foreach (var word in dict[i])
                    {
                        if (IsValid(temp, word))
                            res++;
                    }
                }
            }
            return res;
        }

        static bool IsValid(string s, string t)
        {
            var count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != t[i])
                    count++;
                if (count > 1)
                    return false;
            }
            return count == 1;
        }
    }
}
