
using System;
using System.Collections.Generic;

namespace NthDigit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 1231241444;
            Console.WriteLine(FindNthDigit(n));
        }

        public static int FindNthDigit(int n)
        {
            var record = new long[8];
            long pow = 1, li = 1, hi = n;
            for (int i = 0; i < record.Length; i++)
            {
                record[i] = 9 * pow;
                pow *= 10;
            }
            while (li < hi)
            {
                var mid = li + (hi - li) / 2;
                var count = Count(record, mid);
                if (count > n) hi = mid;
                else li = mid + 1;
            }
            var left = (int)(n - Count(record, li - 1));
            return (left == 0 ? (li - 1).ToString()[^1] : li.ToString()[left - 1]) - '0';
        }

        public static long Count(long[] record, long n)
        {
            var index = 0;
            long count = 0, pow = 1;
            while (index < record.Length && n > record[index])
            {
                count += record[index] * (index + 1);
                index++;
                pow *= 10;
            }
            return count + (n - pow + 1) * (index + 1);
        }
    }
}
