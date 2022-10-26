using System;

namespace NumberOfDistinctBinaryStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var s = "001010011110111000111101101101010000101010011100001";
            var k = 8;
            Console.WriteLine(CountDistinctStrings(s, k));
        }

        public static int CountDistinctStrings(string s, int k)
        {
            long num = s.Length - k + 1, mod = 1_000_000_000 + 7;
            return (int)Pow(num, mod);
        }

        public static long Pow(long num, long mod)
        {
            if (num == 0) return 1;
            var pow = Pow(num / 2, mod) % mod;
            return num % 2 == 0 ? pow * pow % mod : pow * pow * 2 % mod;
        }
    }
}
