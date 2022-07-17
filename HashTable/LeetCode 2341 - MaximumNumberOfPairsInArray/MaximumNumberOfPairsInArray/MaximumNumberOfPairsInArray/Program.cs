using System;
using System.Linq;

namespace MaximumNumberOfPairsInArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int[] NumberOfPairs(int[] nums)
        {
            var freq = nums.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
            var res = new int[2];
            foreach (var f in freq.Values)
            {
                res[0] += f / 2;
                res[1] += f % 2;
            }
            return res;
        }
    }
}
