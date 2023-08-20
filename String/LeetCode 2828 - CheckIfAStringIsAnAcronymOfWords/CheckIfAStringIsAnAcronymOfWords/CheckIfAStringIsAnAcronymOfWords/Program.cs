using System;
using System.Collections.Generic;
using System.Linq;

namespace CheckIfAStringIsAnAcronymOfWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public bool IsAcronym(IList<string> words, string s)
        {
            return string.Join("", words.Select(x => x[0])) == s;
        }
    }
}
