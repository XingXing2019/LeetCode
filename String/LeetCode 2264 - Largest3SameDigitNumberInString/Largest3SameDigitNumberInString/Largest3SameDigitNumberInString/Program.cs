using System;

namespace Largest3SameDigitNumberInString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public string LargestGoodInteger(string num)
        {
            var res = -1;
            var count = 0;
            var digit = num[0];
            foreach (var l in num)
            {
                if (l == digit)
                    count++;
                else
                {
                    digit = l;
                    count = 1;
                }
                if (count == 3)
                    res = Math.Max(res, int.Parse(new string(digit, 3)));
            }
            return res == -1 ? "" : res.ToString("000");
        }
    }
}
