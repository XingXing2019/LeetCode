using System;
using System.Collections.Generic;

namespace DesignHitCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    public class HitCounter
    {
        private Queue<int> queue;
        /** Initialize your data structure here. */
        public HitCounter()
        {
            queue = new Queue<int>();
        }

        /** Record a hit.
            @param timestamp - The current timestamp (in seconds granularity). */
        public void Hit(int timestamp)
        {
            queue.Enqueue(timestamp);
        }

        /** Return the number of hits in the past 5 minutes.
            @param timestamp - The current timestamp (in seconds granularity). */
        public int GetHits(int timestamp)
        {
            while (queue.Count != 0 && queue.Peek() <= timestamp - 300)
                queue.Dequeue();
            return queue.Count;
        }
    }
}
