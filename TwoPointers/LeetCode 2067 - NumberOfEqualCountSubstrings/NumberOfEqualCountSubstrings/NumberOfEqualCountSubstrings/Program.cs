using System;
using System.Linq;

namespace NumberOfEqualCountSubstrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var s = "aaabcbbcc";
            var count = 3;
            Console.WriteLine(EqualCountSubstrings(s, count));
        }
        public static int EqualCountSubstrings(string s, int count)
        {
            var res = 0;
            for (int i = 1; i <= 26 && i * count <= s.Length; i++)
                res += CountSubstring(s, i * count, count);
            return res;
        }

        public static int CountSubstring(string s, int len, int count)
        {
            var record = new int[26];
            int res = 0, li = 0, hi = 0;
            while (hi < len)
                record[s[hi++] - 'a']++;
            hi--;
            while (li < s.Length)
            {
                if (record.All(x => x == 0 || x == count))
                    res++;
                if (hi + 1 >= s.Length) break;
                record[s[li++] - 'a']--;
                record[s[++hi] - 'a']++;
            }
            return res;
        }
    }
}
