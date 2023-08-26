using System;
using System.Collections.Generic;

namespace MaximalRange
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 5, 4, 3, 6 };
            Console.WriteLine(MaximumLengthOfRanges(nums));
        }

        public static int[] MaximumLengthOfRanges(int[] nums)
        {
            var stack = new Stack<int>();
            var left = new int[nums.Length];
            var right = new int[nums.Length];
            var res = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                while (stack.Count != 0 && nums[i] > nums[stack.Peek()])
                    stack.Pop();
                left[i] = stack.Count == 0 ? i : i - stack.Peek() - 1;
                stack.Push(i);
            }
            stack.Clear();
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                while (stack.Count != 0 && nums[i] > nums[stack.Peek()])
                    stack.Pop();
                right[i] = stack.Count == 0 ? nums.Length - i : stack.Peek() - i;
                stack.Push(i);
            }
            for (int i = 0; i < nums.Length; i++)
                res[i] = left[i] + right[i];
            return res;
        }
    }
}
