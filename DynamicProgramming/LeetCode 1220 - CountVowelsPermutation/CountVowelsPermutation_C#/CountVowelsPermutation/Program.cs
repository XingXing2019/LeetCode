using System;
using System.Linq;

namespace CountVowelsPermutation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int CountVowelPermutation(int n)
        {
            var vowels = new long[5];
            Array.Fill(vowels, 1);
            long mod = 1_000_000_000 + 7;
            for (int i = 1; i < n; i++)
            {
                var temp = new long[5];
                temp[0] = (vowels[1] + vowels[2] + vowels[4]) % mod;
                temp[1] = (vowels[0] + vowels[2]) % mod;
                temp[2] = (vowels[1] + vowels[3]) % mod;
                temp[3] = (vowels[2]) % mod;
                temp[4] = (vowels[2] + vowels[3]) % mod;
                for (int j = 0; j < 5; j++)
                    vowels[j] = temp[j];
            }
            return (int)(vowels.Sum() % mod);
        }
    }
}
