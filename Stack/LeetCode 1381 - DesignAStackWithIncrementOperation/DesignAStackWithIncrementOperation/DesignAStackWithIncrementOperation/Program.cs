using System;
using System.Collections.Generic;

namespace DesignAStackWithIncrementOperation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    public class CustomStack
    {
        private List<int> stack;
        private int maxSize;
        public CustomStack(int maxSize)
        {
            this.maxSize = maxSize;
            stack = new List<int>();
        }

        public void Push(int x)
        {
            if(stack.Count < maxSize)
                stack.Add(x);
        }

        public int Pop()
        {
            var res = -1;
            if (stack.Count > 0)
            {
                res = stack[^1];
                stack.RemoveAt(stack.Count - 1);
            }
            return res;
        }

        public void Increment(int k, int val)
        {
            for (int i = 0; i < k && i < stack.Count; i++)
                stack[i] += val;
        }
    }
}
