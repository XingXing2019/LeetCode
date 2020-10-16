//创建resEnd指针指向m + n - 1的位置(nums1中刚好能容纳两个数组中有效数字的位置)，创建p1End和p2End，分别指向两个数组中最后一个有效数字。
//如果m等于0，则直接将nums2中的所有元素拷贝到nums1中。
//否则在p1End和p2End都不越界的条件下遍历。如果p1End指向的数字大于p2End指向的数字，则将resEnd指向的数字换为p1End指向的数字，并使p1End前移一位。
//否则换为p2End指向的数字，并使p2End前移一位。无论替换那个数字，都使resEnd前移一位。
//遍历结束后，如果p2End和resEnd还没有到数组头，则证明nums2中剩下的数字都比nums1的数字小，则需要将他们拷贝到nums1的前端。
using System;

namespace MergeSortedArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums1 = { 2, 0 };
            int m = 1;
            int[] nums2 = { 1 };
            int n = 1;
            Merge(nums1, m, nums2, n);
        }
        static void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int point1 = m - 1, point2 = n - 1, index = m + n - 1;
            while (point1 >= 0 && point2 >= 0)
            {
                if (nums1[point1] > nums2[point2])
                    nums1[index--] = nums1[point1--];
                else
                    nums1[index--] = nums2[point2--];
            }
            while (point1 >= 0)
                nums1[index--] = nums1[point1--];
            while (point2 >= 0)
                nums1[index--] = nums2[point2--];
        }
    }
}
