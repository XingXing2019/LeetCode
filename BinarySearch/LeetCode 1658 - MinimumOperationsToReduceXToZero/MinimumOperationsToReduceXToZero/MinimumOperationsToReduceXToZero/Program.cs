using System;

namespace MinimumOperationsToReduceXToZero
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = {1, 1};
            int x = 2;
            Console.WriteLine(MinOperations(nums, x));
        }
        static int MinOperations(int[] nums, int x)
        {
            int[] prefix = new int[nums.Length + 1], suffix = new int[nums.Length + 1];
            var res = int.MaxValue;
            for (int i = 1; i < prefix.Length; i++)
            {
                prefix[i] = prefix[i - 1] + nums[i - 1];
                suffix[i] = suffix[i - 1] + nums[^i];
            }
            for (int i = 0; i < prefix.Length && x - prefix[i] >= 0; i++)
            {
                var index = Array.BinarySearch(suffix, 0, suffix.Length - i, x - prefix[i]);
                if (index >= 0)
                    res = Math.Min(res, i + index);
            }
            return res == int.MaxValue ? -1 : res;
        }
    }
}
