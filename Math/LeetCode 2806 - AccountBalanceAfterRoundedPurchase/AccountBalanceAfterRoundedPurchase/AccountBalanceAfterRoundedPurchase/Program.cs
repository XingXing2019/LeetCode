using System;

namespace AccountBalanceAfterRoundedPurchase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int AccountBalanceAfterPurchase(int purchaseAmount)
        {
            return 100 - (purchaseAmount % 10 < 5 ? purchaseAmount / 10 * 10 : (purchaseAmount / 10 + 1) * 10);
        }
    }
}
