using System;

namespace FindTheDivisibilityArrayOfAString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int[] DivisibilityArray(string word, int m)
        {
            var res = new int[word.Length];
            long mod = 0;
            for (int i = 0; i < word.Length; i++)
            {
                long digit = word[i] - '0';
                res[i] = (digit + mod) % m == 0 ? 1 : 0;
                mod = (digit + mod) * 10 % m;
            }
            return res;
        }
    }
}
