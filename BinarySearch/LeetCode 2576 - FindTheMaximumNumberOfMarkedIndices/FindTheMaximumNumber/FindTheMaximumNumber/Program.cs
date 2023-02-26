using System;

namespace FindTheMaximumNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 78, 27, 48, 86, 44, 26, 40, 16, 69, 40, 64, 12, 48, 66, 7 };
            Console.WriteLine(MaxNumOfMarkedIndices(nums));
        }

        public static int MaxNumOfMarkedIndices(int[] nums)
        {
            Array.Sort(nums);
            var small = nums[..(nums.Length / 2)];
            var large = nums[(nums.Length / 2)..];
            int res = 0, li = 0;
            foreach (var num in small)
            {
                var target = num * 2;
                var index = BinarySearch(large, target, li);
                if (index >= large.Length) break;
                li = index + 1;
                res += 2;
            }
            return res;
        }

        private static int BinarySearch(int[] arr, int target, int li)
        {
            var hi = arr.Length;
            while (li < hi)
            {
                var mid = li + (hi - li) / 2;
                if (arr[mid] >= target)
                    hi = mid;
                else
                    li = mid + 1;
            }
            return li;
        }
    }
}
