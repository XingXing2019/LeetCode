using System;
using System.Collections;

namespace ImplementQueueUsingStacks
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    public class MyQueue
    {
        private Stack data = new Stack();
        /** Initialize your data structure here. */
        public MyQueue()
        {

        }
        /** Push element x to the back of queue. */
        public void Push(int x)
        {
            Stack tem = new Stack();
            while (data.Count != 0)
                tem.Push((int)data.Pop());
            tem.Push(x);
            while (tem.Count != 0)
                data.Push((int)tem.Pop());
        }
        /** Removes the element from in front of queue and returns that element. */
        public int Pop()
        {
            return (int)data.Pop();
        }
        /** Get the front element. */
        public int Peek()
        {
            return (int)data.Peek();
        }
        /** Returns whether the queue is empty. */
        public bool Empty()
        {
            return data.Count == 0 ? true : false;
        }
    }

}
