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
        private Stack data = new Stack();
        private Stack minStack = new Stack();
        public MinStack()
        {

        }
        public void Push(int x)
        {
            data.Push(x);
            if (minStack.Count == 0)
                minStack.Push(x);
            else
            {
                if (x > (int)minStack.Peek())
                    x = (int)minStack.Peek();
                minStack.Push(x);
            }
        }
        public void Pop()
        {
            data.Pop();
            minStack.Pop();
        }

        public int Top()
        {
            return (int)data.Peek();
        }
        public int GetMin()
        {
            return (int)minStack.Peek();
        }
    }
}
