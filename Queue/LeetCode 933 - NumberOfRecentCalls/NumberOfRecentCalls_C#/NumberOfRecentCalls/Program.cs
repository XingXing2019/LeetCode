using System;
using System.Collections;
using System.Collections.Generic;

namespace NumberOfRecentCalls
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    public class RecentCounter
    {
        private Queue<int> queue;
        private int count;
        public RecentCounter()
        {
            queue = new Queue<int>();
            count = 0;
        }

        public int Ping(int t)
        {
            queue.Enqueue(t);
            count++;
            while (count != 0 && queue.Peek() < t - 3000)
            {
                queue.Dequeue();
                count--;
            }
            return count;
        }
    }

}
