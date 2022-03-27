using System;
using System.Linq;

namespace FindPalindromeWithFixedLength
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int intLength = 5, pos = 600;
            Console.WriteLine(FindPalindrome(intLength, pos));
        }

        public static long[] KthPalindrome(int[] queries, int intLength)
        {
            var res = new long[queries.Length];
            for (int i = 0; i < queries.Length; i++)
                res[i] = FindPalindrome(intLength, queries[i]);
            return res;
        }

        public static long FindPalindrome(int intLength, int pos)
        {
            if (intLength == 1) return pos > 9 ? -1 : pos;
            if (intLength == 2) return pos > 9 ? -1 : pos * 10 + pos;
            var digits = (long) Math.Ceiling((double)intLength / 2) - 1;
            long pow = (long) Math.Pow(10, digits);
            if (pos > 9 * pow) return -1;
            var div = pos % pow == 0 ? pos / pow : pos / pow + 1;
            var mod = pos % pow == 0 ? pow - 1 : pos % pow - 1;
            var front = (div * pow + mod).ToString();
            var reverse = intLength % 2 == 0 ? front.Reverse().ToArray() : front.Reverse().ToArray()[1..];
            var back = string.Join("", reverse);
            return long.Parse(front + back);
        }
    }
}
