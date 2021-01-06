using System;

namespace WaysToSplitArrayIntoThreeSubarrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 2, 2, 2, 5, 0 };
            Console.WriteLine(WaysToSplit(nums));
        }
        static int WaysToSplit(int[] nums)
        {
            for (int i = 1; i < nums.Length; i++)
                nums[i] += nums[i - 1];
            long res = 0;
            int mod = 1_000_000_000 + 7;
            for (int i = 0; i <= nums.Length - 3; i++)
            {
                int li = i + 1, hi = nums.Length - 1;
                while (li < hi)
                {
                    int mid = li + (hi - li) / 2;
                    if (nums[mid] - nums[i] <= nums[^1] - nums[mid]) li = mid + 1;
                    else hi = mid;
                }
                var max = li;
                li = i + 1; hi = nums.Length - 1;
                while (li < hi)
                {
                    int mid = li + (hi - li) / 2;
                    if (nums[mid] - nums[i] >= nums[i]) hi = mid;
                    else li = mid + 1;
                }
                var min = li;
                res += Math.Max(0, max - min);
            }
            return (int) (res % mod);
        }
    }
}
