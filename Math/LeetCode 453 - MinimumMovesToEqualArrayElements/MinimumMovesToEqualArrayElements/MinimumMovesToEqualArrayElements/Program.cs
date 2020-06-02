//思路为每次将数组中最小的n-1个数字加一。相当于每次将最大的数字减一，直到数组中最大数字与最小数字相同。
//所以需要操作的次数等于数组中每个数字与最小数字之差的和。
using System;

namespace MinimumMovesToEqualArrayElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = {1};
            Console.WriteLine(MinMoves(nums));
        }
        static int MinMoves(int[] nums)
        {
            int min = nums[0];
            foreach (var num in nums)
                min = Math.Min(min, num);
            int res = 0;
            foreach (var num in nums)
                res += num - min;
            return res;
        }
    }
}
