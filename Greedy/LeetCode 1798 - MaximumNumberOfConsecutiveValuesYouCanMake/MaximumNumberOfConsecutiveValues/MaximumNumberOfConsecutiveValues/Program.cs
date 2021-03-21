using System;
using System.Collections.Generic;
using System.Linq;

namespace MaximumNumberOfConsecutiveValues
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] coins = {1, 1, 1, 4};
            Console.WriteLine(GetMaximumConsecutive(coins));
        }
        public static int GetMaximumConsecutive(int[] coins)
        {
            Array.Sort(coins);
            int res = 1;
            foreach (var coin in coins)
            {
                if(coin > res) break;
                res += coin;
            }
            return res;
        }
    }
}
