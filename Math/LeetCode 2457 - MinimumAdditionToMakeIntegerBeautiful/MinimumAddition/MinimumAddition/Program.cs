using System;

namespace MinimumAddition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            long n = 495;
            var target = 6;
            Console.WriteLine(MakeIntegerBeautiful(n, target));
        }

        public static long MakeIntegerBeautiful(long n, int target)
        {
            long pow = 1, res = 0, sum = CalcSum(n);
            while (sum > target)
            {
                var digit = n % 10;
                var add = 10 - digit;
                res += add * pow;
                n = (n + add) / 10;
                sum = CalcSum(n);
                pow *= 10;
            }
            return res;
        }

        private static long CalcSum(long n)
        {
            long sum = 0;
            while (n != 0)
            {
                sum += n % 10;
                n /= 10;
            }
            return sum;
        }
    }
}
