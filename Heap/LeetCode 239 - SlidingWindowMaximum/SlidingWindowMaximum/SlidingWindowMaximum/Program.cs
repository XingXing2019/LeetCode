using System;
using System.Collections.Generic;

namespace SlidingWindowMaximum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = {1, 3, -1, -3, 5, 3, 6, 7};
            int k = 3;
            Console.WriteLine(MaxSlidingWindow_Dp(nums, k));
        }
        static int[] MaxSlidingWindow_Heap(int[] nums, int k)
        {
            var heap = new SortedList<int, int>();
            var res = new int[nums.Length - k + 1];
            for (int i = 0; i <= nums.Length; i++)
            {
                if (i >= k)
                {
                    res[i - k] = heap.Keys[^1];
                    heap[nums[i - k]]--;
                    if (heap[nums[i - k]] == 0)
                        heap.Remove(nums[i - k]);
                    if (i == nums.Length) break;
                }
                if (!heap.ContainsKey(nums[i]))
                    heap[nums[i]] = 0;
                heap[nums[i]]++;
            }
            return res;
        }
        static int[] MaxSlidingWindow_Dp(int[] nums, int k)
        {
            int[] leftMax = new int[nums.Length];
            int[] rightMax = new int[nums.Length];
            int left = nums[0], right = nums[^1];
            for (int i = 0; i < nums.Length; i++)
            {
                left = i % k == 0 ? nums[i] : Math.Max(left, nums[i]);
                leftMax[i] = left;
            }
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                right = i == nums.Length - 1 || (i + 1) % k == 0 ? nums[i] : Math.Max(right, nums[i]);
                rightMax[i] = right;
            }
            var res = new int[nums.Length - k + 1];
            for (int i = 0; i < res.Length; i++)
                res[i] = Math.Max(rightMax[i], leftMax[i + k - 1]);
            return res;
        }
    }
}
