using System;

namespace MinimumFlips
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 2, b = 6, c = 5;
            Console.WriteLine(MinFlips(a, b, c));
        }
        static int MinFlips(int a, int b, int c)
        {
            int count = 0;
            while (a != 0 || b != 0 || c != 0)
            {
                if(((a & 1) | (b & 1)) != (c & 1))
                {
                    count++;
                    if (((a & 1) ^ (b & 1)) == (c & 1))
                        count++;
                }
                a >>= 1;
                b >>= 1;
                c >>= 1;
            }
            return count;
        }
    }
}
