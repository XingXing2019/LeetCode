using System;

namespace CalculateMoneyInLeetcodeBank
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 4;
            Console.WriteLine(TotalMoney(n));
        }
        static int TotalMoney(int n)
        {
            var weeks = n / 7;
            var days = n % 7;
            return 28 * weeks + 7 * (weeks - 1) * weeks / 2 + (weeks + 1 + weeks + days) * days / 2;
        }
    }
}
