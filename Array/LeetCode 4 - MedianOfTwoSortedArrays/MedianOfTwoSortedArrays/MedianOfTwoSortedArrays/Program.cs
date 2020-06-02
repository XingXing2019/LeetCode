using System;
using System.Collections.Generic;

namespace MedianOfTwoSortedArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            var nums = new List<int>();
            int index1 = 0, index2 = 0;
            while (index1 < nums1.Length && index2 < nums2.Length)
            {
                if (nums1[index1] < nums2[index2])
                    nums.Add(nums1[index1++]);
                else
                    nums.Add(nums2[index2++]);
            }
            if (index1 != nums1.Length)
            {
                while (index1 < nums1.Length)
                    nums.Add(nums1[index1++]);
            }
            else if (index2 != nums2.Length)
            {
                while (index2 < nums2.Length)
                    nums.Add(nums2[index2++]);
            }
            if (nums.Count % 2 != 0)
                return (double)nums[(nums.Count - 1) / 2];
            return ((double)nums[(nums.Count / 2)] + (double)nums[nums.Count / 2 - 1]) / 2;
        }
    }
}
