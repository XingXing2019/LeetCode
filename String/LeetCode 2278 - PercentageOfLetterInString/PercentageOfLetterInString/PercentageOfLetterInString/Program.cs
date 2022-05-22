using System;
using System.Linq;

namespace PercentageOfLetterInString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int PercentageLetter(string s, char letter)
        {
            var count = s.Count(x => x == letter);
            return (int)((double)count / s.Length * 100);
        }
    }
}
