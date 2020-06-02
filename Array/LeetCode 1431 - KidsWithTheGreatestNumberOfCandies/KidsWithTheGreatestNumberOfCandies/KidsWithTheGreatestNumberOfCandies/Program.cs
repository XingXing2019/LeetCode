using System;
using System.Collections.Generic;
using System.Linq;

namespace KidsWithTheGreatestNumberOfCandies
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public IList<bool> KidsWithCandies(int[] candies, int extraCandies) 
        {
            var res = new bool[candies.Length];
            var max = candies.Max(x => x);
            for (int i = 0; i < res.Length; i++)
            {
                if (candies[i] + extraCandies >= max)
                    res[i] = true;
            }
            return res;
        }
    }
}
