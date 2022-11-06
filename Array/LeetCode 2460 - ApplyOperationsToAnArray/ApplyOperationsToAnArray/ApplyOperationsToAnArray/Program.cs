using System;

namespace ApplyOperationsToAnArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int[] ApplyOperations(int[] nums)
        {
            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i] != nums[i + 1]) continue;
                nums[i] *= 2;
                nums[i + 1] = 0;
            }
            var res = new int[nums.Length];
            var index = 0;
            foreach (var num in nums)
            {
                if (num == 0) continue;
                res[index++] = num;
            }
            return res;
        }
    }
}
