using System;

namespace MovementOfRobots
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { -2, 0, 2 };
            var s = "RLL";
            var d = 3;
            Console.WriteLine(SumDistance(nums, s, d));
        }

        public static int SumDistance(int[] nums, string s, int d)
        {
            long res = 0, mod = 1_000_000_000 + 7;
            var final = new long[nums.Length];
            for (int i = 0; i < nums.Length; i++)
                final[i] = s[i] == 'L' ? nums[i] - d : nums[i] + d;
            Array.Sort(final);
            var prefix = new long[nums.Length];
            for (int i = 0; i < final.Length; i++)
                prefix[i] = i == 0 ? final[i] : prefix[i - 1] + final[i];
            for (int i = 0; i < final.Length - 1; i++)
                res = (res + prefix[^1] - prefix[i] - (final.Length - i - 1) * final[i]) % mod;
            return (int)(res % mod);
        }
    }
}
