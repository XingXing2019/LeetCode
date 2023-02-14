using System;

namespace WiggleSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 3, 2, 2, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 4 };
            WiggleSort(nums);
        }
        static void WiggleSort(int[] nums)
        {
            var copy = new int[nums.Length];
            Array.Copy(nums, copy, nums.Length);
            Array.Sort(copy);
            int li = 0, hi = copy.Length - 1, index = 0;
            while (li < hi)
            {
                nums[index++] = copy[li++];
                nums[index++] = copy[hi--];
            }
            if (index < nums.Length)
                nums[index] = copy[li];
        }
    }
}
