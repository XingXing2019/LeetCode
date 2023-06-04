using System;
using System.Collections.Generic;

namespace MinimizeStringLength
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int MinimizedStringLength(string s)
        {
            var set = new HashSet<char>();
            foreach (var l in s)
                set.Add(l);
            return set.Count;
        }
    }
}
