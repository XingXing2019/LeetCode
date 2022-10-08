using System;
using System.Collections.Generic;

namespace MaxStack
{
    class Program
    {
        static void Main(string[] args)
        {
            var stack = new MaxStack();
            stack.Push(5);
            stack.Push(1);
            stack.Push(-5);

            Console.WriteLine(stack.PopMax());
            Console.WriteLine(stack.PopMax());
            Console.WriteLine(stack.Top());
        }
    }
    public class MaxStack
    {
        private Stack<int> stack;
        private Stack<int> maxStack;
        public MaxStack()
        {
            stack = new Stack<int>();
            maxStack = new Stack<int>();
        }

        public void Push(int x)
        {
            stack.Push(x);
            int max = maxStack.Count == 0 ? x : Math.Max(maxStack.Peek(), x);
            maxStack.Push(max);
        }
        public int Pop()
        {
            maxStack.Pop();
            return stack.Pop();
        }
        public int Top()
        {
            return stack.Peek();
        }

        public int PeekMax()
        {
            return maxStack.Peek();
        }

        public int PopMax()
        {
            var max = PeekMax();
            var temp = new Stack<int>();
            while (Top() != max)
                temp.Push(Pop());
            Pop();
            while (temp.Count != 0)
                Push(temp.Pop());
            return max;
        }
    }
}
