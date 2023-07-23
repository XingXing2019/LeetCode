using System;
using System.Collections.Generic;

namespace LargestElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public long MaxArrayValue(int[] nums)
        {
            var stack = new Stack<long>();
            long res = 0;
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                if (stack.Count == 0 || nums[i] > stack.Peek())
                    stack.Push(nums[i]);
                else
                    stack.Push(stack.Pop() + nums[i]);
                res = Math.Max(res, stack.Peek());
            }
            return res;
        }
    }
}
