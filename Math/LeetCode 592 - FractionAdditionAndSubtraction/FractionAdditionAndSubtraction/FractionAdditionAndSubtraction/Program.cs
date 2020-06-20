using System;
using System.Collections.Generic;
using System.Text;

namespace FractionAdditionAndSubtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            string expression = "-1/2-1/2";
            Console.WriteLine(FractionAddition(expression));
        }
        static string FractionAddition(string expression)
        {
            var temp = new StringBuilder(expression);
            for (int i = 0; i < temp.Length; i++)
                if (temp[i] == '-')
                    temp.Insert(i++, '+');
            var fractions = temp.ToString().Split('+', StringSplitOptions.RemoveEmptyEntries);
            var numerators = new List<long>();
            var denominators = new List<long>();
            foreach (var fraction in fractions)
            {
                var nums = fraction.Split('/');
                numerators.Add(long.Parse(nums[0]));
                denominators.Add(long.Parse(nums[1]));
            }
            long demoinator = 1, numerator = 0;
            foreach (var num in denominators)
                demoinator *= num;
            for (int i = 0; i < numerators.Count; i++)
            {
                numerators[i] *= demoinator / denominators[i];
                numerator += numerators[i];
            }
            long gcd = CalcGCD(numerator, demoinator);
            return $"{numerator / gcd}/{demoinator / gcd}";
        }

        static long CalcGCD(long num1, long num2)
        {
            if (num1 == 0) return num2;
            num1 = Math.Abs(num1);
            num2 = Math.Abs(num2);
            for (long i = Math.Min(num1, num2); i >= 1; i--)
            {
                if (num1 % i == 0 && num2 % i == 0)
                    return i;
            }
            return -1;
        }
       
    }
}
