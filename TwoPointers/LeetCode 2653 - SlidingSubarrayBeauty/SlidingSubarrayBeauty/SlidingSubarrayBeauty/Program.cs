using System;

namespace SlidingSubarrayBeauty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, -1, -3, -2, 3 };
            int k = 3, x = 2;
            Console.WriteLine(GetSubarrayBeauty(nums, k, x));
        }

        public static int[] GetSubarrayBeauty(int[] nums, int k, int x)
        {
            var freq = new int[101];
            var res = new int[nums.Length - k + 1];
            for (int i = 0; i < k; i++)
                freq[nums[i] + 50]++;
            for (int i = k; i <= nums.Length; i++)
            {
                res[i - k] = GetXSmallest(freq, x);
                if (i == nums.Length) break;
                freq[nums[i - k] + 50]--;
                freq[nums[i] + 50]++;
            }
            return res;
        }

        private static int GetXSmallest(int[] freq, int x)
        {
            for (int i = 0; i < 50; i++)
            {
                if (freq[i] == 0) continue;
                x -= freq[i];
                if (x > 0) continue;
                return i - 50;
            }
            return 0;
        }
    }
}
