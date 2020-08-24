using System;

namespace FindKthBitInNthBinaryString
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 20, k = 7;
            Console.WriteLine(FindKthBit(n, k));
        }
        static char FindKthBit(int n, int k)
        {
            if (n == 1) return '0';
            int len = (1 << n) - 1;
            if (k == len / 2 + 1) return '1';
            if (k < len / 2 + 1) return FindKthBit(n - 1, k);
            return (char) ('1' - FindKthBit(n - 1, len - k + 1) + '0');
        }
    }
}
