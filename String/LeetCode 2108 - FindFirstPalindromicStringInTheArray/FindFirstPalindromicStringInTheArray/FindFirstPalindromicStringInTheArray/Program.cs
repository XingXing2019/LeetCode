using System;
using System.Linq;

namespace FindFirstPalindromicStringInTheArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public string FirstPalindrome(string[] words)
        {
            foreach (var word in words)
            {
                if (word == string.Join("", word.Reverse()))
                    return word;
            }
            return "";
        }
    }
}
