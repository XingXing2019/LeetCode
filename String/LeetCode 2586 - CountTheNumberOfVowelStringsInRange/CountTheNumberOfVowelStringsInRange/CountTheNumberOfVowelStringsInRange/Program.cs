using System;
using System.Collections.Generic;
using System.Linq;

namespace CountTheNumberOfVowelStringsInRange
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int VowelStrings(string[] words, int left, int right)
        {var vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };
            return words[left..(right + 1)].Count(x => vowels.Contains(x[0]) && vowels.Contains(x[^1]));
            
        }
    }
}
