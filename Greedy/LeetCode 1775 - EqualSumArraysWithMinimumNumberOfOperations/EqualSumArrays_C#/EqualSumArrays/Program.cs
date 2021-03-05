using System;
using System.Linq;

namespace EqualSumArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] num1 = {5, 6, 4, 3, 1, 2};
            int[] nums2 = {6, 3, 3, 1, 4, 5, 3, 4, 1, 3, 4};
            Console.WriteLine(MinOperations(num1, nums2));
        }
        static int MinOperations(int[] nums1, int[] nums2)
        {
            int sum1 = nums1.Sum(), sum2 = nums2.Sum(), diff = Math.Abs(sum1 - sum2);
            return sum1 > sum2 ? GetMinOperators(nums1, nums2, diff) : GetMinOperators(nums2, nums1, diff);
        }

        static int GetMinOperators(int[] nums1, int[] nums2, int diff)
        {
            Array.Sort(nums1, (a, b) => b - a);
            Array.Sort(nums2);
            int res = 0, p1 = 0, p2 = 0;
            while (p1 < nums1.Length && p2 < nums2.Length && diff > 0)
            {
                if (nums1[p1] - 1 > 6 - nums2[p2])
                    diff -= Math.Min(diff, nums1[p1++] - 1);
                else
                    diff -= Math.Min(diff, 6 - nums2[p2++]);
                res++;
            }
            while (p1 < nums1.Length && diff > 0)
            {
                diff -= Math.Min(diff, nums1[p1++] - 1);
                res++;
            }
            while (p2 < nums2.Length && diff > 0)
            {
                diff -= Math.Min(diff, 6 - nums2[p2++]);
                res++;
            }
            return diff == 0 ? res : -1;
        }
    }
}
