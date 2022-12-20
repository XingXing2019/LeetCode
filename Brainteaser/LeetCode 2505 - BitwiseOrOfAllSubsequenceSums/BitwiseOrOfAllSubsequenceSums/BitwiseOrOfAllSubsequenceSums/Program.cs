using System;
using System.Linq;

namespace BitwiseOrOfAllSubsequenceSums
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 35, 20, 18, 4 };
            Console.WriteLine(SubsequenceSumOr(nums));
        }

        public static long SubsequenceSumOr(int[] nums)
        {
            long res = 0;
            for (int i = 0; i < 64; i++)
            {
                foreach (var num in nums)
                {
                    if ((((long)num >> i) & 1) != 1) continue;
                    res += 1L << i;
                    break;
                }
            }
            int car = 0;
            for (int i = 0; i < 64; i++)
            {
                var count = nums.Count(x => (((long)x >> i) & 1) == 1);
                if (car + count != 0)
                    res |= 1L << i;
                car = (count + car) / 2;
            }
            return res;
        }
    }
}
