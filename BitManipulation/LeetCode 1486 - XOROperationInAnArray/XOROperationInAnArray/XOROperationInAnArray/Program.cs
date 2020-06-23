//按照题目要求，随便做做就好了。
using System;

namespace XOROperationInAnArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int XorOperation(int n, int start)
        {
            int res = start;
            for (int i = 1; i < n; i++)
            {
                int temp = start + 2 * i;
                res ^= temp;
            }
            return res;
        }
    }
}
