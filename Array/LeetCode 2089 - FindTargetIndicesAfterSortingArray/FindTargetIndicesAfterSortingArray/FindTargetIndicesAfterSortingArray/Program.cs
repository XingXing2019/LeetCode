using System;
using System.Collections.Generic;

namespace FindTargetIndicesAfterSortingArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public IList<int> TargetIndices(int[] nums, int target)
        {
            int count = 0, smaller = 0;
            foreach (var num in nums)
            {
                if (num == target) count++;
                else if (num < target) smaller++;
            }
            var res = new List<int>();
            var start = smaller;
            for (int i = 0; i < count; i++)
                res.Add(start++);
            return res;
        }
    }
}
