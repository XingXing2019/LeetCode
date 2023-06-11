using System;

namespace NeitherMinimumNorMaximum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int FindNonMinOrMax(int[] nums)
        {
            int min = int.MaxValue, max = int.MinValue;
            foreach (var num in nums)
            {
                min = Math.Min(min, num);
                max = Math.Max(max, num);
            }
            foreach (var num in nums)
            {
                if (num == min || num == max) continue;
                return num;
            }
            return -1;
        }
    }
}
