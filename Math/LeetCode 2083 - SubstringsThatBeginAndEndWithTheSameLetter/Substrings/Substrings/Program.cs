using System;
using System.Collections.Generic;
using System.Linq;

namespace Substrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public long NumberOfSubstrings(string s)
        {
            var dict = new Dictionary<char, long>();
            foreach (var c in s)
            {
                if (!dict.ContainsKey(c))
                    dict[c] = 0;
                dict[c]++;
            }
            long res = 0;
            foreach (var freq in dict.Values)
                res += (1 + freq) * freq / 2;
            return res;
        }
    }
}
