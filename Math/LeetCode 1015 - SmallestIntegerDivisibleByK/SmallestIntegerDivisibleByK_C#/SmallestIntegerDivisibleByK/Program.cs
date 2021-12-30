//如果K为偶数，则一定没有符合条件的解，直接返回-1.
//创建tem存储对K的模。每次让tem末尾加一。如果tem可以被K整除，则返回加了几次一。
using System;

namespace SmallestIntegerDivisibleByK
{
    class Program
    {
        static void Main(string[] args)
        {
            int K = 9;
            Console.WriteLine(SmallestRepunitDivByK(K));
        }
        static int SmallestRepunitDivByK(int K)
        {
            if (K % 2 == 0)
                return -1;
            int tem = 0;
            for (int i = 0; i < K; i++)
            {
                tem = (tem * 10 + 1) % K;
                if (tem == 0)
                    return i + 1;
            }
            return -1;
        }
    }
}
