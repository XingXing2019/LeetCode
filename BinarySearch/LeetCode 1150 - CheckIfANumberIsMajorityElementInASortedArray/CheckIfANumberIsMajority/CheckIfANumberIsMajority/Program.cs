using System;

namespace CheckIfANumberIsMajority
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 2, 4, 5, 5, 5, 5, 5, 6, 6 };
            int target = 6;
            Console.WriteLine(IsMajorityElement(nums, target));
        }
        static bool IsMajorityElement(int[] nums, int target)
        {
            if (nums.Length == 1)
                return nums[0] == target;
            int li = 0, hi = nums.Length - 1;
            while (li < hi)
            {
                int mid = li + (hi - li) / 2;
                if (nums[mid] >= target)
                    hi = mid;
                else
                    li = mid + 1;
            }
            int low = li;
            li = 0;
            hi = nums.Length - 1;
            while (li <= hi)
            {
                int mid = li + (hi - li) / 2;
                if (nums[mid] > target)
                    hi = mid - 1;
                else
                    li = mid + 1;
            }
            int high = li;
            return high - low > nums.Length / 2;
        }
    }
}
