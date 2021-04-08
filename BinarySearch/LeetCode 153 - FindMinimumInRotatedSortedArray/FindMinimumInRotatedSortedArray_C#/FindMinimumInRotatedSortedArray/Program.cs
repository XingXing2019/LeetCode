//二分搜索，创建li和hi指针分别指向数组头尾。在li小于hi的条件下循环。
//创建mid指向li和hi的中点。如果mid指向的数字不小于li和hi指向的数字，则将li移动到mid的下一位。
//否则将hi移动到mid。最后返回li指向的数字。
using System;

namespace FindMinimumInRotatedSortedArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int FindMin(int[] nums)
        {
            int li = 0, hi = nums.Length - 1;
            while (li < hi)
            {
                int mid = li + (hi - li) / 2;
                if (nums[mid] >= nums[li] && nums[mid] >= nums[hi])
                    li = mid + 1;
                else
                    hi = mid;
            }
            return nums[li];
        }
        static int FindMin_2(int[] nums)
        {
            int li = 0, hi = nums.Length - 1;
            while (li < hi)
            {
                int mid = li + (hi - li) / 2;
                if (nums[mid] < nums[hi])
                    hi = mid;
                else
                    li = mid + 1;
            }
            return nums[li];
        }
    }
}
