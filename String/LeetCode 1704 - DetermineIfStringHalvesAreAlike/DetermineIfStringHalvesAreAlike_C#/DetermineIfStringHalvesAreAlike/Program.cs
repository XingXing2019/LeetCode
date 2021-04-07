using System;
using System.Collections.Generic;
using System.Linq;

namespace DetermineIfStringHalvesAreAlike
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public bool HalvesAreAlike(string s)
        {
            var vowels = new HashSet<char> {'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U'};
            var count = 0;
            for (int i = 0; i < s.Length / 2; i++)
            {
                if (vowels.Contains(s[i]))
                    count++;
                if (vowels.Contains(s[^(i + 1)]))
                    count--;
            }
            return count == 0;
        }
    }
}
