using System;

namespace NumberOf1Bits
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int HammingWeight(uint n)
        {
            int count = 0;
            while (n != 0)
            {
                count += (int)n & 1;
                n >>= 1;
            }
            return count;
        }
    }
}
