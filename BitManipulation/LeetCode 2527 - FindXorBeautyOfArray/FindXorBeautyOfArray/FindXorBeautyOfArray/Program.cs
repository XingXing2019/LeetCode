using System;

namespace FindXorBeautyOfArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int XorBeauty(int[] nums)
        {
            int combo = nums.Length * nums.Length, res = 0;
            for (int i = 0; i < 32; i++)
            {
                int zero = 0, one = 0;
                foreach (var num in nums)
                {
                    if (((num >> i) & 1) == 1)
                        one++;
                    else
                        zero++;
                }
                var orZero = zero * zero;
                var effectiveOne = (combo - orZero) * one;
                if (effectiveOne % 2 != 0)
                    res += 1 << i;
            }
            return res;
        }
    }
}
