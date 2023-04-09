using System;

namespace MinimizeTheMaximumDifferenceOfPairs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int MinimizeMax(int[] nums, int p)
        {
            Array.Sort(nums);
            int li = 0, hi = nums[^1] - nums[0];
            while (li <= hi)
            {
                var mid = li + (hi - li) / 2;
                if (IsValid(nums, mid, p))
                    hi = mid - 1;
                else
                    li = mid + 1;
            }
            return li;
        }

        private bool IsValid(int[] nums, int mid, int p)
        {
            var count = 0;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] - nums[i - 1] <= mid)
                {
                    count++;
                    i++;
                }
            }
            return count >= p;
        }
    }
}
