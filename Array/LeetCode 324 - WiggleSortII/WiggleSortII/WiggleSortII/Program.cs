using System;

namespace WiggleSortII
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 4, 5, 5, 6 };
            WiggleSort(nums);
        }
        public static void WiggleSort(int[] nums)
        {
            var copy = new int[nums.Length];
            Array.Copy(nums, copy, nums.Length);
            Array.Sort(copy);
            int li = (int)Math.Floor((double)(nums.Length - 1) / 2), hi = nums.Length - 1;
            var index = 0;
            for (int i = 0; i < Math.Ceiling((double)nums.Length / 2); i++)
            {
                nums[index++] = copy[li--];
                if (index >= nums.Length) break;
                nums[index++] = copy[hi--];
            }
        }
    }
}
