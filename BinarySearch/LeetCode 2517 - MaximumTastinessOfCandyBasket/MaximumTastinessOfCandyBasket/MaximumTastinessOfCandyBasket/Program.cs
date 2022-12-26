using System;

namespace MaximumTastinessOfCandyBasket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] prices = { 13, 5, 1, 8, 21, 2 };
            var k = 3;
            Console.WriteLine(MaximumTastiness(prices, k));
        }

        public static int MaximumTastiness(int[] price, int k)
        {
            Array.Sort(price);
            int li = 0, hi = price[^1] - price[0];
            while (li <= hi)
            {
                var mid = li + (hi - li) / 2;
                int count = 1, start = price[0];
                for (int i = 1; i < price.Length; i++)
                {
                    if (price[i] < start + mid) continue;
                    start = price[i];
                    count++;
                }
                if (count < k)
                    hi = mid - 1;
                else
                    li = mid + 1;
            }
            return hi;
        }
    }
}
