//使用二分查询。创建li和hi分别指向数组头和数组尾。
//在li小于hi的条件下遍历。创建mid指向li和hi的中点。如果mid指向元素小于其下一个元素，则下一个元素有可能为峰值，那么将li移到mid下一个元素。下一次循环在li右面找可能比他小的元素。
//如果mid指向元素大于其下一元素，则mid有可能为峰值，则将hi移到mid。下一次循环在mid的左面寻找比他小的元素。
//最终li和hi一定会相遇，则返回li即为最终峰值。
using System;

namespace FindPeakElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 2, 3, 1 };
            Console.WriteLine(FindPeakElement(nums));
        }
        static int FindPeakElement(int[] nums)
        {
            int li = 0;
            int hi = nums.Length - 1;
            while (li < hi)
            {
                int mid = li + (hi - li) / 2;
                if (nums[mid] < nums[mid + 1])
                    li = mid + 1;
                else
                    hi = mid;
            }
            return li;
        }
    }
}
