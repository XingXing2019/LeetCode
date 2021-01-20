using System;

namespace MissingElementInSortedArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = {1, 2, 4};
            int k = 3;
            Console.WriteLine(MissingElement_BinarySearch(nums, k));
        }
        static int MissingElement_BinarySearch(int[] nums, int k)
        {
            int li = 0, hi = nums.Length - 1;
            int missing = nums[^1] - nums[0] - (hi - li);
            if (missing < k)
                return nums[^1] + k - missing;
            while (li + 1 < hi)
            {
                int mid = li + (hi - li) / 2;
                missing = nums[mid] - nums[li] - (mid - li);
                if (missing < k)
                {
                    k -= missing;
                    li = mid;
                }
                else
                    hi = mid;
            }
            return nums[li] + k;
        }
        public int MissingElement(int[] nums, int k)
        {
            for (int i = 1; i < nums.Length; i++)
            {
                k -= nums[i] - nums[i - 1] - 1;
                if (k <= 0) return nums[i] + k - 1;
            }
            return nums[^1] + k;
        }
    }
}
