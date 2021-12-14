using System;
using System.Collections.Generic;

namespace NumberOfVisiblePeopleInAQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int[] CanSeePersonsCount(int[] heights)
        {
            var res = new int[heights.Length];
            var stack = new Stack<int>();
            for (int i = 0; i < heights.Length; i++)
            {
                while (stack.Count != 0 && heights[stack.Peek()] < heights[i])
                {
                    var index = stack.Pop();
                    res[index]++;
                }
                if (stack.Count != 0)
                    res[stack.Peek()]++;
                stack.Push(i);
            }
            return res;
        }
    }
}
