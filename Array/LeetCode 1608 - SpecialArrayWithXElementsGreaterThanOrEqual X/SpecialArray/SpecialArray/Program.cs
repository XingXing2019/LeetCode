using System;

namespace SpecialArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = {3, 9, 7, 8, 3, 8, 6, 6};
            Console.WriteLine(SpecialArray(nums));
        }
        static int SpecialArray(int[] nums)
        {
            Array.Sort(nums);
            for (int i = 0; i <= nums.Length; i++)
            {
                int li = 0, hi = nums.Length - 1;
                while (li < hi)
                {
                    int mid = li + (hi - li) / 2;
                    if (nums[mid] >= i)
                        hi = mid;
                    else
                        li = mid + 1;
                }
                if (nums[li] < i) li++;
                if (nums.Length - li == i)
                    return i;
            }
            return -1;
        }
    }
}
