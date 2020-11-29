using System;
using System.Collections.Generic;

namespace DesignFrontMiddleBackQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            var queue = new FrontMiddleBackQueue();
            queue.PushFront(1);
            queue.PushBack(2);
            queue.PushMiddle(3);
            queue.PushMiddle(4);
            Console.WriteLine(queue.PopFront());
            Console.WriteLine(queue.PopMiddle());
            Console.WriteLine(queue.PopMiddle());
            Console.WriteLine(queue.PopBack());
            Console.WriteLine(queue.PopFront());
        }
    }

    public class FrontMiddleBackQueue
    {
        private List<int> queue;
        public FrontMiddleBackQueue()
        {
            queue = new List<int>();
        }

        public void PushFront(int val)
        {
            queue.Insert(0, val);
        }

        public void PushMiddle(int val)
        {
            queue.Insert(queue.Count / 2, val);
        }

        public void PushBack(int val)
        {
            queue.Add(val);
        }

        public int PopFront()
        {
            if (queue.Count == 0) return -1;
            var res = queue[0];
            queue.RemoveAt(0);
            return res;
        }

        public int PopMiddle()
        {
            if (queue.Count == 0) return -1;
            var index = queue.Count % 2 == 0 ? queue.Count / 2 - 1 : queue.Count / 2;
            var res = queue[index];
            queue.RemoveAt(index);
            return res;
        }

        public int PopBack()
        {
            if (queue.Count == 0) return -1;
            var res = queue[^1];
            queue.RemoveAt(queue.Count - 1);
            return res;
        }
    }

}
