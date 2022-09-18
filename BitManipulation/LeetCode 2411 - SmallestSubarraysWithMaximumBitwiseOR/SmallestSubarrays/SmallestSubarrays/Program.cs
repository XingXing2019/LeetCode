using System;

namespace SmallestSubarrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 8, 10, 8 };
            Console.WriteLine(SmallestSubarrays(nums));
        }

        public static int[] SmallestSubarrays(int[] nums)
        {
            var res = new int[nums.Length];
            var masks = new int[nums.Length][];
            for (int i = 0; i < nums.Length; i++)
                masks[i] = new int[32];
            for (int i = 0; i < 32; i++)
            {
                var one = -1;
                for (int j = nums.Length - 1; j >= 0; j--)
                {
                    if ((nums[j] & (1 << i)) != 0)
                        one = j;
                    masks[j][^(i + 1)] = one;
                }
            }
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < 32; j++)
                {
                    if (masks[i][j] == -1)
                        continue;
                    res[i] = Math.Max(res[i], masks[i][j] - i + 1);
                }
                res[i] = Math.Max(res[i], 1);
            }
            return res;
        }
    }
}
