//遍历数组，如果当前元素大于或等于target，则直接返回当前i指针。(由于数组值排好序的，如果遍历到第一个大于target的元素，则就应该在该点插入target)
//如果遍历结束后还没有返回，那么数组中所有元素都小于target，则要在数组最后插入target，所以返回nums.Length。
using System;

namespace SearchInsertPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 3, 5, 6 };
            int target = 0;
            Console.WriteLine(SearchInsert(nums, target));
        }
        static int SearchInsert(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] >= target)
                    return i;
            }
            return nums.Length;
        }
    }
}
