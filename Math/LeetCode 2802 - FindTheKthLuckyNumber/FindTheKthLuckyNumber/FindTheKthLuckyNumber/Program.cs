using System;

namespace FindTheKthLuckyNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var k = 12;
            Console.WriteLine(KthLuckyNumber(k));
        }

        public static string KthLuckyNumber(int k)
        {
            int pow = 2, digits = 1;
            var res = "";
            while (k - pow > 0)
            {
                k -= pow;
                pow *= 2;
                digits++;
            }
            k--;
            while (k != 0)
            {
                res = (k % 2 == 0 ? "4" : "7") + res;
                k /= 2;
            }
            return new string('4', digits - res.Length) + res;
        }
    }
}
