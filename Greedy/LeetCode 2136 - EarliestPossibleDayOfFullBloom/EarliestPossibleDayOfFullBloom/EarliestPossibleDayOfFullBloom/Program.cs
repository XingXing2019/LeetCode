using System;
using System.Linq;

namespace EarliestPossibleDayOfFullBloom
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int EarliestFullBloom(int[] plantTime, int[] growTime)
        {
            var seeds = new int[plantTime.Length][];
            for (int i = 0; i < seeds.Length; i++)
                seeds[i] = new[] { plantTime[i], growTime[i] };
            seeds = seeds.OrderByDescending(x => x[1]).ToArray();
            int start = 0, max = 0;
            foreach (var seed in seeds)
            {
                var bloom = start + seed[0] + seed[1];
                max = Math.Max(max, bloom);
                start += seed[0];
            }
            return max;
        }
    }
}
