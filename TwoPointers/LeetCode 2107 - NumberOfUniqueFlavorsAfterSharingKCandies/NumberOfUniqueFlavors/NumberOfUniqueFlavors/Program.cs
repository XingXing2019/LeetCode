using System;
using System.Linq;

namespace NumberOfUniqueFlavors
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] candies = { 1, 2, 3, 2, 2, 2 };
            int k = 3;
            Console.WriteLine(ShareCandies(candies, k));
        }
        public static int ShareCandies(int[] candies, int k)
        {
            var dict = candies.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
            int li = 0, hi = -1;
            for (int i = 0; i < k; i++)
            {
                dict[candies[++hi]]--;
                if (dict[candies[hi]] == 0)
                    dict.Remove(candies[hi]);
            }
            int res = dict.Count;
            while (hi < candies.Length - 1)
            {
                res = Math.Max(res, dict.Count);
                if (!dict.ContainsKey(candies[li]))
                    dict[candies[li]] = 0;
                dict[candies[li++]]++;
                dict[candies[++hi]]--; 
                if (dict[candies[hi]] == 0)
                    dict.Remove(candies[hi]);
            }
            return Math.Max(res, dict.Count);
        }
    }
}
