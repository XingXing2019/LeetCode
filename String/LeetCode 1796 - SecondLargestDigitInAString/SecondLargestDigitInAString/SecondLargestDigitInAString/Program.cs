using System;

namespace SecondLargestDigitInAString
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "abc1111";
            Console.WriteLine(SecondHighest(s));
        }
        public static int SecondHighest(string s)
        {
            int max1 = int.MinValue, max2 = int.MinValue;
            foreach (var l in s)
            {
                if (!char.IsDigit(l)) continue;
                if (l - '0' >= max1)
                {
                    if (l - '0' == max1) continue;
                    max2 = max1;
                    max1 = l - '0';
                }
                else if (l - '0' > max2)
                    max2 = l - '0';
            }
            return max2 == int.MinValue ? -1 : max2;
        }
    }
}
