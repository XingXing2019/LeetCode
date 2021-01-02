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
            Console.WriteLine(MaxSlidingWindow(nums, k));
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
    }
}
