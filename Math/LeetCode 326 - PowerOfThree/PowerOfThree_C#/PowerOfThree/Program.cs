//在int型中，3的幂的最大值为1162261467。所以只要返回n是否为1162261467的约数即可。需要注意判断n小于等于0的情况。
using System;

namespace PowerOfThree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static bool IsPowerOfThree(int n)
        {
            if (n <= 0)
                return false;
            return 1162261467 % n == 0;
        }
    }
}
