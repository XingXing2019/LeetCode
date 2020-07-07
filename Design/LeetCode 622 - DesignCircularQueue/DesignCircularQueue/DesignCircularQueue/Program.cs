using System;
using System.Collections.Generic;

namespace DesignCircularQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    public class MyCircularQueue
    {
        private List<int> nums;
        private int capacity;
        public MyCircularQueue(int k)
        {
            nums = new List<int>();
            capacity = k;
        }

        public bool EnQueue(int value)
        {
            if (nums.Count >= capacity) return false;
            nums.Add(value);
            return true;
        }

        public bool DeQueue()
        {
            if (nums.Count == 0) return false;
            nums.RemoveAt(0);
            return true;
        }

        public int Front()
        {
            if (nums.Count == 0) return -1;
            return nums[0];
        }

        public int Rear()
        {
            if (nums.Count == 0) return -1;
            return nums[^1];
        }

        public bool IsEmpty()
        {
            return nums.Count == 0;
        }

        public bool IsFull()
        {
            return nums.Count == capacity;
        }
    }
}
