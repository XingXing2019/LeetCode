using System;

namespace MinimumCostOfBuyingCandiesWithDiscount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int MinimumCost(int[] cost)
        {
            Array.Sort(cost, (a, b) => b - a);
            int count = 0, res = 0;
            for (int i = 0; i < cost.Length; i++)
            {
                count++;
                if (count % 3 == 0) continue;
                res += cost[i];
            }
            return res;
        }
    }
}
