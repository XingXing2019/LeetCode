using System;

namespace CountSubstrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int NumberOfSpecialSubstrings(string s)
        {
            int li = 0, hi = 0, res = 0;
            var record = new int[26];
            while (hi < s.Length)
            {
                record[s[hi] - 'a']++;
                while (record[s[hi] - 'a'] > 1)
                    record[s[li++] - 'a']--;
                res += hi - li + 1;
                hi++;
            }
            return res;
        }
    }
}
