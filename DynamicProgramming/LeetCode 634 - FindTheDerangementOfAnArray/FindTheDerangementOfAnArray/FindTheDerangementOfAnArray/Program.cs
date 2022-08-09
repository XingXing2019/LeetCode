using System;

namespace FindTheDerangementOfAnArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int FindDerangement(int n)
        {
            if (n == 1) return 0;
            long first = 0, second = 1, mod = 1_000_000_000 + 7;
            for (int i = 3; i <= n; i++)
            {
                long temp = (first + second) * (i - 1) % mod;
                first = second;
                second = temp;
            }
            return (int) (second % mod);
        }
    }
}
