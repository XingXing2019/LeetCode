//有四种选择方案，1.将前三个数改为最大值，2。将后三个数改为最小值。3.将第一个数改为最大值，后两个数改为最小值。4.将前两个数改为最大值，最后一个数改为最小值。
//结果为四种方案中结果最小的那个。
using System;
using System.Linq;

namespace MinimumDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int MinDifference(int[] nums)
        {
            if (nums.Length <= 3) return 0;
            Array.Sort(nums);
            var options = new int[4];
            options[0] = nums[^1] - nums[3];
            options[1] = nums[^2] - nums[2];
            options[2] = nums[^3] - nums[1];
            options[3] = nums[^4] - nums[0];
            return options.Min();
        }
    }
}
