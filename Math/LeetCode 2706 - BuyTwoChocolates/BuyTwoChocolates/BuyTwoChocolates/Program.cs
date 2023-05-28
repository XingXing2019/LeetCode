using System;

namespace BuyTwoChocolates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int BuyChoco(int[] prices, int money)
        {
            int min = int.MaxValue, secMin = int.MaxValue;
            foreach (var price in prices)
            {
                if (price < min)
                {
                    secMin = min;
                    min = price;
                }
                else if (price < secMin)
                    secMin = price;
            }
            return min + secMin <= money ? money - min - secMin : money;
        }
    }
}
