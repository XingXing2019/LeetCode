using System;
using System.Collections.Generic;

namespace CountTheNumberOfConsistentStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int CountConsistentStrings(string allowed, string[] words)
        {
            var set = new HashSet<char>(allowed);
            var res = 0;
            foreach (var word in words)
            {
                var isConsistent = true;
                foreach (var letter in word)
                {
                    if (!set.Contains(letter))
                    {
                        isConsistent = false;
                        break;
                    }
                }
                if (isConsistent) res++;
            }
            return res;
        }
    }
}
