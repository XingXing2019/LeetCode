using System;

namespace FindTheArrayConcatenationValue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 5, 14, 13, 8, 12 };
            Console.WriteLine(FindTheArrayConcVal(nums));
        }

        public static long FindTheArrayConcVal(int[] nums)
        {
            long res = 0;
            int li = 0, hi = nums.Length - 1;
            while (li <= hi)
            {
                var num = li == hi ? nums[li++].ToString() : $"{nums[li++]}{nums[hi--]}";
                res += long.Parse(num);
            }
            return res;
        }
    }
}
