using System;
using System.Collections.Generic;

namespace FractionToRecurringDecimal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numerator = -1, denominator = -2147483648;
            Console.WriteLine(FractionToDecimal(numerator, denominator));
        }

        public static string FractionToDecimal(int numerator, int denominator)
        {
            if (numerator == 0) return "0";
            var isNeg = (numerator < 0 || denominator < 0) && !(numerator < 0 && denominator < 0);
            var numeratorL = Math.Abs((long)numerator);
            var denominatorL = Math.Abs((long)denominator);
            if (numeratorL % denominatorL == 0) return isNeg ? $"-{numeratorL / denominatorL}" : $"{numeratorL / denominatorL}";
            var digits = new List<long> { numeratorL / denominatorL };
            var reminder = numeratorL % denominatorL * 10;
            var dict = new Dictionary<long, long>();
            while (!dict.ContainsKey(reminder) && reminder != 0)
            {
                digits.Add(reminder / denominatorL);
                dict[reminder] = digits.Count - 1;
                reminder = reminder % denominatorL * 10;
            }
            var index = reminder == 0 ? -1 : dict[reminder];
            var res = $"{digits[0]}.";
            for (int i = 1; i < digits.Count; i++)
            {
                if (i == index)
                    res += '(';
                res += digits[i];
            }
            if (index != -1) res += ')';
            return isNeg ? $"-{res}" : $"{res}";
        }
    }
}
