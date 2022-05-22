using System;
using System.Linq;

namespace MinimumLinesToRepresentALineChart
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int MinimumLines(int[][] stockPrices)
        {
            if (stockPrices.Length == 1) return 0;
            stockPrices = stockPrices.OrderBy(x => x[0]).ToArray();
            decimal slop = stockPrices[1][1] == stockPrices[0][1]
                ? decimal.MaxValue
                : (decimal)(stockPrices[1][0] - stockPrices[0][0]) / (stockPrices[1][1] - stockPrices[0][1]);
            var res = 1;
            for (int i = 2; i < stockPrices.Length; i++)
            {
                decimal newSlop = stockPrices[i][1] == stockPrices[i - 1][1]
                    ? decimal.MaxValue
                    : (decimal)(stockPrices[i][0] - stockPrices[i - 1][0]) / (stockPrices[i][1] - stockPrices[i - 1][1]);
                if (newSlop == slop) continue;
                slop = newSlop;
                res++;
            }
            return res;
        }
    }
}
