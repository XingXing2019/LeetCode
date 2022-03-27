using System;
using System.Collections.Generic;

namespace FindTheDifferenceOfTwoArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public IList<IList<int>> FindDifference(int[] nums1, int[] nums2)
        {
            var set1 = new HashSet<int>(nums1);
            var set2 = new HashSet<int>(nums2);
            var res = new List<IList<int>>();
            foreach (var num in set1)
            {
                if (res.Count == 0) res.Add(new List<int>());
                if (set2.Contains(num)) continue;
                res[0].Add(num);
            }
            foreach (var num in set2)
            {
                if (res.Count == 1) res.Add(new List<int>());
                if (set1.Contains(num)) continue;
                res[1].Add(num);
            }
            return res;
        }

    }
}
