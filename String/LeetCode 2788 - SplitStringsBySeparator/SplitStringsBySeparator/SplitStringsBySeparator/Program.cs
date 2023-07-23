using System;
using System.Collections.Generic;
using System.Linq;

namespace SplitStringsBySeparator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public IList<string> SplitWordsBySeparator(IList<string> words, char separator)
        {
            return words.SelectMany(x => x.Split(separator, StringSplitOptions.RemoveEmptyEntries)).ToList();
        }
    }
}
