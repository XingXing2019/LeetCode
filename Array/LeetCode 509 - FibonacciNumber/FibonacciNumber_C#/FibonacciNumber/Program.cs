//创建a等于0，b等于1。循环N-1次。每次使tem等于a，a等于b，b等于a+b。最后返回b。需要特殊处理N等于0的情况。
using System;

namespace FibonacciNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 1;
            Console.WriteLine(Fib(N));
        }
        static int Fib(int N)
        {
            if (N == 0)
                return 0;
            int a = 0;
            int b = 1;
            for (int i = 0; i < N - 1; i++)
            {
                int tem = a;
                a = b;
                b = tem + b;
            }
            return b;
        }
    }
}
