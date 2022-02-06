using System;
using System.Collections.Generic;

namespace SmallestValueOfTheRearrangedNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            long num = 95005;
            Console.WriteLine(SmallestNumber(num));
        }
        public static long SmallestNumber(long num)
        {
            if (num == 0) return num;
            var isNeg = num < 0;
            if (isNeg) num *= -1;
            var digits = new List<long>();
            int count = 0;
            while (num != 0)
            {
                if (num % 10 == 0) count++;
                digits.Add(num % 10);
                num /= 10;
            }
            digits.Sort();
            if (isNeg) digits.Reverse();
            else if (count != 0)
            {
                digits[0] = digits[count];
                digits[count] = 0;
            }
            long res = 0;
            foreach (var digit in digits)
                res = res * 10 + digit;
            return isNeg ? -res : res;
        }
    }
}
