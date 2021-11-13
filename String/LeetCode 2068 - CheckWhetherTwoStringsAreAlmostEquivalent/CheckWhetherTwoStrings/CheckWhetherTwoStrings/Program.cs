using System;
using System.Linq;

namespace CheckWhetherTwoStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word1 = "abcdeef", word2 = "abaaacc";
            Console.WriteLine(CheckAlmostEquivalent(word1, word2));
        }

        public static bool CheckAlmostEquivalent(string word1, string word2)
        {
            var record = new int[26];
            foreach (var l in word1)
                record[l - 'a']++;
            foreach (var l in word2)
                record[l - 'a']--;
            return record.Max(Math.Abs) <= 3;
        }
    }
}
