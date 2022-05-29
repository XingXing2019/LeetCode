using System;
using System.Collections.Generic;
using System.Linq;

namespace StepsToMakeArrayNonDecreasing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 10, 1, 2, 3, 4, 5, 6, 1, 2, 3 };
            Console.WriteLine(TotalSteps(nums));
        }

        public static int TotalSteps(int[] nums)
        {
            var stack = new Stack<int>();
            var res = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                var max = 0;
                while (stack.Count != 0 && nums[i] >= nums[stack.Peek()])
                    max = Math.Max(max, res[stack.Pop()]);
                if (stack.Count != 0)
                    res[i] = max + 1;
                stack.Push(i);
            }
            return res.Max();
        }
    }
}
