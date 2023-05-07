using System;
using System.Collections.Generic;

namespace FindTheLongestValidObstacle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] obstacles = { 1, 2, 3, 2 };
            Console.WriteLine(LongestObstacleCourseAtEachPosition(obstacles));
        }

        public static int[] LongestObstacleCourseAtEachPosition(int[] obstacles)
        {
            var res = new int[obstacles.Length];
            var order = new List<int>();
            for (int i = 0; i < obstacles.Length; i++)
            {
                if (order.Count == 0 || order[^1] <= obstacles[i])
                {
                    order.Add(obstacles[i]);
                    res[i] = order.Count;
                }
                else
                {
                    var index = BinarySearch(order, obstacles[i]);
                    res[i] = index + 1;
                    order[index] = obstacles[i];
                }
            }
            return res;
        }

        public static int BinarySearch(List<int> nums, int target)
        {
            int li = 0, hi = nums.Count - 1;
            while (li <= hi)
            {
                var mid = li + (hi - li) / 2;
                if (nums[mid] <= target)
                    li = mid + 1;
                else
                    hi = mid - 1;
            }
            return li;
        }
    }
}
