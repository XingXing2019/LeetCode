using System;
using System.Linq;

namespace ApplyOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 60, 72, 87, 89, 63, 52, 64, 62, 31, 37, 57, 83, 98, 94, 92, 77, 94, 91, 87, 100, 91, 91, 50, 26 };
            var k = 4;
            Console.WriteLine(CheckArray(nums, k));
        }

        public static bool CheckArray(int[] nums, int k)
        {
            if (k == 1) return true;
            var decrease = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] -= decrease;
                if (nums[i] < 0)
                    return false;
                decrease += nums[i];
                if (i - k + 1 >= 0)
                    decrease -= nums[i - k + 1];
            }
            return nums[^1] == 0;
        }
    }
}
