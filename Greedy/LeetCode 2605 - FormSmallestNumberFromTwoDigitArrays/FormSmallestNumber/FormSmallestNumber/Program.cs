using System;
using System.Collections.Generic;
using System.Linq;

namespace FormSmallestNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int MinNumber(int[] nums1, int[] nums2)
        {
            int min1 = nums1.Min(), min2 = nums2.Min(), res = int.MaxValue;
            HashSet<int> set1 = new HashSet<int>(nums1), set2 = new HashSet<int>(nums2);
            foreach (var num in set1)
            {
                if (set2.Contains(num))
                    res = Math.Min(res, num);
            }
            return Math.Min(res, Math.Min(min1 * 10 + min2, min2 * 10 + min1));
        }
    }
}
