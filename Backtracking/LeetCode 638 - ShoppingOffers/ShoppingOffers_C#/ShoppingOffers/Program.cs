using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingOffers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int ShoppingOffers(IList<int> price, IList<IList<int>> special, IList<int> needs)
        {
            var res = int.MaxValue;
            DFS(price, special, needs, 0, ref res);
            return res;
        }

        public void DFS(IList<int> prices, IList<IList<int>> special, IList<int> needs, int price, ref int min)
        {
            if (needs.Any(x => x < 0))
                return;
            if (needs.All(x => x == 0))
                min = Math.Min(min, price);
            foreach (var offer in special)
            {
                var copy = new List<int>(needs);
                for (int j = 0; j < offer.Count - 1; j++)
                    needs[j] -= offer[j];
                DFS(prices, special, needs, price + offer[^1], ref min);
                needs = copy;
            }
            for (int i = 0; i < needs.Count; i++)
                price += prices[i] * needs[i];
            min = Math.Min(min, price);
        }
    }
}
