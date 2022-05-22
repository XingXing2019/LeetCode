using System;
using System.Linq;

namespace MaximumBagsWithFullCapacityOfRocks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int MaximumBags(int[] capacity, int[] rocks, int additionalRocks)
        {
            var bags = new int[capacity.Length];
            for (int i = 0; i < bags.Length; i++)
                bags[i] = capacity[i] - rocks[i];
            Array.Sort(bags);
            var res = 0;
            for (int i = 0; i < bags.Length && additionalRocks > 0; i++)
            {
                if (additionalRocks < bags[i])
                    return res;
                res++;
                additionalRocks -= bags[i];
            }
            return res;
        }
    }
}
