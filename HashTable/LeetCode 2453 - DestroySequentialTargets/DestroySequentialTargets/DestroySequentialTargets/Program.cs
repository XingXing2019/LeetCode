using System;
using System.Collections.Generic;
using System.Linq;

namespace DestroySequentialTargets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 304415643, 213512562, 667776528, 854523075, 291102158 };
            var space = 4;
            Console.WriteLine(DestroyTargets(nums, space));
        }

        public static int DestroyTargets(int[] nums, int space)
        {
            var freq = nums.GroupBy(x => x % space).ToDictionary(x => x.Key, x => x.ToList());
            var max = freq.Max(x => x.Value.Count);
            return freq.Where(x => x.Value.Count == max).SelectMany(x => x.Value).Min();
        }
    }
}
