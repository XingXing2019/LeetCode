//创建一个bool型数组，长度为n，用于记录每个数是否为质数。先将2及其以后的数字设为true。
//从第二个数开始遍历到n。如果当前数字不是质数，则跳过本次遍历，如果当前数字为质数，则当前数字的从2倍开始的所有倍数都不是质数，应设为false。
//最后创建count记录结果，从2到n开始遍历，找出所有质数，记录如count并返回。
using System;
using System.Linq;

namespace CountPrimes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 499979;
            Console.WriteLine(CountPrimes(n));
        }
        static int CountPrimes(int n)
        {
            var isPrime = new bool[n];
            for (int i = 2; i < isPrime.Length; i++)
                isPrime[i] = true;
            for (int i = 2; i < isPrime.Length; i++)
            {
                if (!isPrime[i]) continue;
                for (int j = 2; i * j < n; j++)
                    isPrime[i * j] = false;
            }
            return isPrime.Count(x => x);
        }
    }
}
