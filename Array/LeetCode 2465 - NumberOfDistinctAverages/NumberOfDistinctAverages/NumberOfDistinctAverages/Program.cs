using System;
using System.Collections.Generic;

namespace NumberOfDistinctAverages
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int DistinctAverages(int[] nums)
        {
            var distinct = new HashSet<double>();
            Array.Sort(nums);
            int li = 0, hi = nums.Length - 1;
            while (li < hi)
            {
                var avg = (double)(nums[li++] + nums[hi--]) / 2;
                distinct.Add(avg);
            }
            return distinct.Count;
        }
    }
}
