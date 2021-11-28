using System;

namespace KRadiusSubarrayAverages
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int[] GetAverages(int[] nums, int k)
        {
            var prefix = new long[nums.Length];
            for (int i = 0; i < prefix.Length; i++)
                prefix[i] = i == 0 ? nums[i] : nums[i] + prefix[i - 1];
            var res = new int[nums.Length];
            Array.Fill(res, -1);
            for (int i = 0; i < res.Length; i++)
            {
                if (i - k < 0 || i + k >= nums.Length)
                    continue;
                var left = i - k == 0 ? 0 : prefix[i - k - 1];
                var right = prefix[i + k];
                res[i] = (int) ((right - left) / (2 * k + 1));
            }
            return res;
        }
    }
}
