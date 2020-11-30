using System;
using System.Collections.Generic;

namespace FindTheMostCompetitiveSubsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 2, 4, 3, 3, 5, 4, 9, 6 };
            int k = 4;
            Console.WriteLine(MostCompetitive(nums, k));
        }
        static int[] MostCompetitive(int[] nums, int k)
        {
            var stack = new Stack<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int count = nums.Length - i;
                while (stack.Count != 0 && nums[i] < stack.Peek() && stack.Count + count > k) 
                    stack.Pop();
                if (stack.Count < k)
                    stack.Push(nums[i]);
            }
            var res = stack.ToArray();
            Array.Reverse(res);
            return res;
        }
    }
}
