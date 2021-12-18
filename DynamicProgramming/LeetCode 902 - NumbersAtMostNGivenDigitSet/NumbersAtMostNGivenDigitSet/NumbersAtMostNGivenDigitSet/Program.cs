using System;

namespace NumbersAtMostNGivenDigitSet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] digits = { "3", "4", "8" };
            int n = 4;
            Console.WriteLine(AtMostNGivenDigitSet(digits, n));
        }
        public static int AtMostNGivenDigitSet(string[] digits, int n)
        {
            var num = n.ToString();
            int res = 0, pow = digits.Length;
            for (int i = 1; i < num.Length; i++)
            {
                res += pow;
                pow *= digits.Length;
            }
            var dp = new int[num.Length];
            for (int i = 0; i < digits.Length; i++)
            {
                if (int.Parse(digits[i]) <= num[^1] - '0')
                    dp[^1]++;
                else
                    break;
            }
            pow = digits.Length;
            for (int i = dp.Length - 2; i >= 0; i--)
            {
                int count = 0, index = 0;
                while (index < digits.Length && int.Parse(digits[index]) < num[i] - '0')
                {
                    count++;
                    index++;
                }
                dp[i] = index < digits.Length && int.Parse(digits[index]) == num[i] - '0' ? dp[i + 1] + pow * count : pow * count;
                pow *= digits.Length;
            }
            return res + dp[0];
        }
    }
}
