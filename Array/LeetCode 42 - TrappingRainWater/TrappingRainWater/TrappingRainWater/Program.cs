using System;

namespace TrappingRainWater
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int Trap(int[] height)
        {
            var leftMax = new int[height.Length];
            var rightMax = new int[height.Length];
            int left = 0, right = 0, res = 0;
            for (int i = 0; i < height.Length; i++)
            {
                leftMax[i] = left;
                left = Math.Max(left, height[i]);
                rightMax[height.Length - i - 1] = right;
                right = Math.Max(right, height[height.Length - i - 1]);
            }
            for (int i = 0; i < height.Length; i++)
            {
                var water = Math.Min(leftMax[i], rightMax[i]) - height[i];
                if (water > 0) res += water;
            }
            return res;
        }
    }
}
