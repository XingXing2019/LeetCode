using System;
using System.Collections;
using System.Collections.Generic;

namespace ImplementStackUsingQueues
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }

    public class MyStack
    {
        private Queue<int> queue;
        public MyStack()
        {
            queue = new Queue<int>();
        }

        public void Push(int x)
        {
            var temp = new Queue<int>();
            temp.Enqueue(x);
            while (queue.Count != 0)
                temp.Enqueue(queue.Dequeue());
            while (temp.Count != 0)
                queue.Enqueue(temp.Dequeue());
        }

        public int Pop()
        {
            return queue.Dequeue();
        }

        public int Top()
        {
            return queue.Peek();
        }

        public bool Empty()
        {
            return queue.Count == 0;
        }
    }

}
