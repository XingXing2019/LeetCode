using System;
using System.Linq;

namespace ConstructKPalindromeStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public bool CanConstruct(string s, int k)
        {
            if (s.Length < k)
                return false;
            var record = new int[26];
            for (int i = 0; i < s.Length; i++)
                record[s[i] - 'a']++;
            int odd = record.Count(r => r % 2 != 0);
            return odd <= k;
        }
    }
}
