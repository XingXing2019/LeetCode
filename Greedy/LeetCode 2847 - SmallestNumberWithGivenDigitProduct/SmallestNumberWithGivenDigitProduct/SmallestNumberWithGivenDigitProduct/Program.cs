using System;

namespace SmallestNumberWithGivenDigitProduct
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var n = 50L;
            Console.WriteLine(SmallestNumber(n));
        }

        public static string SmallestNumber(long n)
        {
            if (n < 10) return n.ToString();
            var res = "";
            while (n != 1)
            {
                var hasDigit = false;
                for (int i = 9; i > 1; i--)
                {
                    if (n % i != 0) continue;
                    hasDigit = true;
                    res = i + res;
                    n /= i;
                    break;
                }
                if (!hasDigit) return "-1";
            }
            return res;
        }
    }
}
