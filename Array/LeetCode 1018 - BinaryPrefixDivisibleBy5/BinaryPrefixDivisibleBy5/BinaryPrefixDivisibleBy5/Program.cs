//因为数据量很大，直接计算数字会出现溢出，所以只要记录数字的最后一位，判断随后一位是不是5或者0即可。
using System;
using System.Collections.Generic;

namespace BinaryPrefixDivisibleBy5
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A =
            {
                1, 0, 0, 1, 0, 1, 0, 0, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 1, 0, 1,
                0, 0, 0, 1
            };
            Console.WriteLine(PrefixesDivBy5(A));
        }
        static IList<bool> PrefixesDivBy5(int[] A)
        {
            var res = new bool[A.Length];
            int lastDigit = 0;
            for (int i = 0; i < A.Length; i++)
            {
                lastDigit = (lastDigit * 2 + A[i]) % 10;
                res[i] = lastDigit == 5 || lastDigit == 0;
            }
            return res;
        }
    }
}
