//例如[25,30]，二进制为11010， 11011， 11100， 11101， 11110，相等的为开头两位，则结果应该为11000.
//先将m和n同时右移，直到两者相等。再将n左移同样步数即使答案。
using System;

namespace BitwiseANDOfNumbersRange
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int RangeBitwiseAnd(int m, int n)
        {
            int step = 0;
            while (m != n)
            {
                m >>= 1;
                n >>= 1;
                step++;
            }
            while (step != 0)
            {
                n <<= 1;
                step--;
            }
            return n;
        }
    }
}
