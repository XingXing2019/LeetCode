using System;
using System.Linq;

namespace PalindromePermutation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public bool CanPermutePalindrome(string s)
        {
            var record = new int[128];
            foreach (var character in s)
                record[character]++;
            var countOdd = record.Count(x => x % 2 != 0);
            return countOdd < 2;
        }
    }
}
