using System;
using System.Collections;

namespace MinStack
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }
    public class MinStack
    {
        private Stack<int> nums;
        private Stack<int> min;
        public MinStack()
        {
            nums = new Stack<int>();
            min = new Stack<int>();
        }
        public void Push(int x)
        {
            nums.Push(x);
            if (min.Count != 0 && x >= min.Peek())
                x = min.Peek();
            min.Push(x);
        }
        public void Pop()
        {
            nums.Pop();
            min.Pop();
        }

        public int Top()
        {
            return nums.Peek();
        }

        public int GetMin()
        {
            return min.Peek();
        }
    }
}
