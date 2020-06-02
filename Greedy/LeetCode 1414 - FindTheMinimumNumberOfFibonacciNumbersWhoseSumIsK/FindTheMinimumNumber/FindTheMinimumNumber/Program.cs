using System;
using System.Collections.Generic;

namespace FindTheMinimumNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int k = 17;
            Console.WriteLine(FindMinFibonacciNumbers(k));
        }
        static int FindMinFibonacciNumbers(int k)
        {
            var fib = new List<int>();
            int pre = 1, cur = 1;
            fib.Add(pre);
            fib.Add(cur);
            while (cur <= k)
            {
                int tem = pre;
                pre = cur;
                cur += tem;
                fib.Add(cur);
            }
            int index = fib.Count - 1;
            int count = 0;
            while (k != 0)
            {
                while (fib[index] > k)
                    index--;
                k -= fib[index];
                count++;
            }
            return count;
        }
    }
}
