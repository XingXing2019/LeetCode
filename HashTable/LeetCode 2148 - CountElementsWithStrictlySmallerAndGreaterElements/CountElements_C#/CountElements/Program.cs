using System;
using System.Linq;

namespace CountElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int CountElements(int[] nums)
        {
            var freq = nums.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
            var ordered = freq.Keys.OrderBy(x => x).ToList();
            var res = 0;
            for (int i = 1; i < ordered.Count - 1; i++)
            {
                res += freq[ordered[i]];
            }
            return res;
        }
    }
}
