using System;

namespace BinaryNumberWithAlternatingBits
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 11;
            Console.WriteLine(HasAlternatingBits(n));
        }
        static bool HasAlternatingBits(int n)
        {
            int mark = n % 2 == 0 ? 1 : 0;
            while (n != 0)
            {
                if (n % 2 == mark)
                    return false;
                mark = n % 2;
                n /= 2;
            }
            return true;
        }
    }
}
