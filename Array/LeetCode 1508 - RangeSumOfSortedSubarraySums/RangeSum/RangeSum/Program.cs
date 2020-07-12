using System;

namespace RangeSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = {1, 2, 3, 4};
            int n = 4, left = 1, right = 5;
            Console.WriteLine(RangeSum(nums, n, left, right));
        }
        static int RangeSum(int[] nums, int n, int left, int right)
        {
            int mod = 1_000_000_000 + 7;
            int[] record = new int[n * (n + 1) / 2];
            int index = 0;
            for (int i = 1; i < nums.Length; i++)
                nums[i] += nums[i - 1];
            for (int i = 0; i < nums.Length; i++)
                for (int j = i; j < nums.Length; j++)
                    record[index++] = i == 0 ? nums[j] : nums[j] - nums[i - 1];
            Array.Sort(record);
            var res = 0;
            for (int i = left - 1; i < right; i++)
                res += record[i] % mod;
            return res;
        }
    }
}
