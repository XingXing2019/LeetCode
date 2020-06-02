//先判断n等于0，1，2的特殊情况。
//创建动态数组tri记录每一个数。长度设为n + 1。将第一个数设为0，第二个和第三个数设为1。
//从第四个数开始遍历，tri[i]等于他之前三个数的和。
//最后返回tri[n]。
using System;

namespace N_thTribonacciNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 3;
            Console.WriteLine(Tribonacci(n));
        }
        static int Tribonacci(int n)
        {
            if (n < 2)
                return n;
            else if (n == 2)
                return 1;
            int[] tri = new int[n + 1];
            tri[0] = 0;
            tri[1] = 1;
            tri[2] = 1;
            for (int i = 3; i <= n; i++)
                tri[i] = tri[i - 3] + tri[i - 2] + tri[i - 1];
            return tri[n];
        }
    }
}
