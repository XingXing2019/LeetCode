using System;
using System.Collections.Generic;

namespace SumOfSubarrayMinimums
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int SumSubarrayMins(int[] arr)
        {
            var stack = new Stack<int>();
            long res = 0, mod = 1_000_000_000 + 7;
            for (int i = 0; i < arr.Length; i++)
            {
                while (stack.Count != 0 && arr[stack.Peek()] > arr[i])
                {
                    var index = stack.Pop();
                    var left = stack.Count == 0 ? index + 1 : index - stack.Peek();
                    var right = i - index;
                    res += (long)arr[index] * left * right;
                }
                stack.Push(i);
            }
            while (stack.Count != 0)
            {
                var index = stack.Pop();
                var left = stack.Count == 0 ? index + 1 : index - stack.Peek();
                var right = arr.Length - index;
                res += (long)arr[index] * left * right;
            }
            return (int)(res % mod);
        }
    }
}
