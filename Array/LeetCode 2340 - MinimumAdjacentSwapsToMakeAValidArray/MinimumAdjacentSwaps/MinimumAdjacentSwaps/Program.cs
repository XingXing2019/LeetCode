using System;

namespace MinimumAdjacentSwaps
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int MinimumSwaps(int[] nums)
        {
            int min = int.MaxValue, max = int.MinValue;
            foreach (var num in nums)
            {
                min = Math.Min(min, num);
                max = Math.Max(max, num);
            }
            int maxIndex = -1, minIndex = nums.Length;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == max)
                    maxIndex = Math.Max(maxIndex, i);
                if (nums[i] == min)
                    minIndex = Math.Min(minIndex, i);
            }
            var res = nums.Length - maxIndex - 1 + minIndex;
            return minIndex > maxIndex ? res - 1 : res;
        }
    }
}
