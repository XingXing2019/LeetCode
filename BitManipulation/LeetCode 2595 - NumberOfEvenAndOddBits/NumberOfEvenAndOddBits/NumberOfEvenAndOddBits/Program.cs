using System;

namespace NumberOfEvenAndOddBits
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int[] EvenOddBit(int n)
        {
            var res = new int[2];
            var digits = 0;
            while (n != 0)
            {
                if ((n & 1) == 1)
                    res[digits % 2]++;
                digits++;
                n >>= 1;
            }
            return res;
        }
    }
}
