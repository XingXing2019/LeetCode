using System;

namespace SmallestStringWithAGivenNumericValue
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 5, k = 73;
            Console.WriteLine(GetSmallestString(n, k));
        }
        static string GetSmallestString(int n, int k)
        {
            var count = (k - n) / 25;
            k -= count * 26;
            n -= count;
            var left = new string('a', n - 1);
            var right = new string('z', count);
            k -= left.Length;
            return left + (char)(k - 1 + 'a') + right;
        }
    }
}
