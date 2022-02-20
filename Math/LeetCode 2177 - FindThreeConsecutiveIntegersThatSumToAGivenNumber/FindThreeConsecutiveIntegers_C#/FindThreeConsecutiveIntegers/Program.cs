using System;

namespace FindThreeConsecutiveIntegers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public long[] SumOfThree(long num)
        {
            return num % 3 != 0
                ? new long[0]
                : new long[] { num / 3 - 1, num / 3, num / 3 + 1 };
        }
    }
}
