using System;

namespace ReverseBits
{
    class Program
    {
        static void Main(string[] args)
        {
            uint n = 4294967293;
            Console.WriteLine(reverseBits(n));
        }
        static uint reverseBits(uint n)
        {
            uint res = 0;
            uint temp = n;
            int step = 0;
            while (temp != 0)
            {
                temp >>= 1;
                step++;
            }
            while (n != 0)
            {
                res ^= n & 1;
                n >>= 1;
                if(n == 0)
                    break;
                res <<= 1;
            }
            for (int i = 0; i < 32 - step; i++)
                res <<= 1;
            return res;
        }
    }
}
