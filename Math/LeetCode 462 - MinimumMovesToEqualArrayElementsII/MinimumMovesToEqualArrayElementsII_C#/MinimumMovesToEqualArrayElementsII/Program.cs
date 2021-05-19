using System;
using System.Linq;

namespace MinimumMovesToEqualArrayElementsII
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 2, 3, 4 };
            Console.WriteLine(MinMoves2(nums));
        }
        static int MinMoves2(int[] nums)
        {
            Array.Sort(nums);
            int sum = nums.Sum(n => n);
            int res = 0;
            int index = nums.Length / 2;
            if (nums.Length % 2 == 0)
            {
                int t1 = nums[index];
                int t2 = nums[index - 1];
                res = Math.Min(GetStep(nums, t1), GetStep(nums, t2));
            }
            else
                res = GetStep(nums, nums[index]);
            return res;
        }
        static int GetStep(int[] nums, int target)
        {
            int step = 0;
            foreach (var n in nums)
                step += Math.Abs(n - target);
            return step;
        }
    }
}
