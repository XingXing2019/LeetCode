using System;

namespace CalculateAmountPaidInTaxes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] brackets = new[]
            {
                new[] { 3, 50 },
                new[] { 7, 10 },
                new[] { 12, 25 },
            };
            int income = 10;
            Console.WriteLine(CalculateTax(brackets, income));
        }
        public static double CalculateTax(int[][] brackets, int income)
        {
            double res = 0;
            for (int i = 0; i < brackets.Length; i++)
            {
                var prev = i == 0 ? 0 : brackets[i - 1][0];
                var earn = Math.Min(income, brackets[i][0]);
                res += (double)Math.Max(0, (earn - prev)) * brackets[i][1] / 100;
            }
            return res;
        }
    }
}
