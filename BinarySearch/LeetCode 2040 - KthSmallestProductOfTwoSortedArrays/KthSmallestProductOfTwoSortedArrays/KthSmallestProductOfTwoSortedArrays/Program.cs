using System;
using System.Linq;

namespace KthSmallestProductOfTwoSortedArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums1 = { 1, 6 }, nums2 = { -10, -10};
            long k = 1;
            Console.WriteLine(KthSmallestProduct(nums1, nums2, k));
        }

        public static long KthSmallestProduct(int[] nums1, int[] nums2, long k)
        {
            long[] products =
            {
                (long)nums1[0] * nums2[^1], (long)nums1[^1] * nums2[0], 
                (long)nums1[0] * nums2[0], (long)nums1[^1] * nums2[^1]
            };
            long li = products.Min(), hi = products.Max();
            while (li <= hi)
            {
                long mid = li + (hi - li) / 2;
                long smaller = 0;
                foreach (var num in nums1)
                    smaller += FindSmaller(num, nums2, mid);
                if (smaller > k - 1)
                    hi = mid - 1;
                else
                    li = mid + 1;
            }
            return hi;
        }


        public static long FindSmaller(long num, int[] nums2, long target)
        {
            if (num == 0) return target > 0 ? nums2.Length : 0;
            int li = 0, hi = nums2.Length - 1;
            while (li <= hi)
            {
                int mid = li + (hi - li) / 2;
                if (num > 0)
                {
                    if (num * nums2[mid] >= target)
                        hi = mid - 1;
                    else
                        li = mid + 1;
                }
                else
                {
                    if (num * nums2[mid] >= target)
                        li = mid + 1;
                    else
                        hi = mid - 1;
                }
            }
            return num > 0 ? li : nums2.Length - li;
        }
    }
}
