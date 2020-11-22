using System;

namespace CheckIfTwoStringArraysAreEquivalent
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static bool ArrayStringsAreEqual(string[] word1, string[] word2)
        {
            return string.Join("", word1) == string.Join("", word2);
        }
    }
}
