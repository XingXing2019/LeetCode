using System;
using System.Collections.Generic;

namespace VowelsOfAllSubstrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public long CountVowels(string word)
        {
            long res = 0;
            var vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };
            for (int i = 0; i < word.Length; i++)
            {
                if (!vowels.Contains(word[i])) continue;
                res += (long) (i + 1) * (word.Length - i);
            }
            return res;
        }
    }
}
