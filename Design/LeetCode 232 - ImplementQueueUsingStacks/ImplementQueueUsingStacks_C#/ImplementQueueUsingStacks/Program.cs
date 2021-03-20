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
        private Stack<int> queue;
        public MyQueue()
        {
            queue = new Stack<int>();
        }
        public void Push(int x)
        {
            var temp = new Stack<int>();
            while (queue.Count != 0)
                temp.Push(queue.Pop());
            queue.Push(x);
            while (temp.Count != 0)
                queue.Push(temp.Pop());
        }
        public int Pop()
        {
            return queue.Pop();
        }
        public int Peek()
        {
            return queue.Peek();
        }
        public bool Empty()
        {
            return queue.Count == 0;
        }
    }

}
