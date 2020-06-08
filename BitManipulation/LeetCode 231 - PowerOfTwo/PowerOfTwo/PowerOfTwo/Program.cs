//n如果为0，返回false。否则，在n模2不等于0的条件下，让n右移一位。最后返回n是否等于1.
using System;

namespace PowerOfTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.MaxValue;
            Console.WriteLine(IsPowerOfTwo(n));
        }
        static bool IsPowerOfTwo(int n)
        {
            if (n == 0) return false;
            while (n % 2 == 0)
                n >>= 1;
            return n == 1;
        }
    }
}
