using System;
using System.Collections.Generic;

namespace DesignCircularDeque
{
    class Program
    {
        static void Main(string[] args)
        {
            var queue = new MyCircularDeque(3);
            Console.WriteLine(queue.InsertLast(1));
            Console.WriteLine(queue.InsertLast(2));
            Console.WriteLine(queue.InsertFront(3));
            Console.WriteLine(queue.InsertFront(4));
            Console.WriteLine(queue.GetRear());
        }
    }
    public class MyCircularDeque
    {
        private List<int> nums;
        private int capacity;
        public MyCircularDeque(int k)
        {
            nums = new List<int>();
            capacity = k;
        }

        public bool InsertFront(int value)
        {
            if (nums.Count < capacity)
            {
                nums.Insert(0, value);
                return true;
            }
            return false;
        }

        public bool InsertLast(int value)
        {
            if (nums.Count < capacity)
            {
                nums.Add(value);
                return true;
            }
            return false;
        }

        public bool DeleteFront()
        {
            if (nums.Count > 0)
            {
                nums.RemoveAt(0);
                return true;
            }
            return false;
        }

        public bool DeleteLast()
        {
            if (nums.Count > 0)
            {
                nums.RemoveAt(nums.Count - 1);
                return true;
            }
            return false;
        }

        public int GetFront()
        {
            return nums.Count == 0 ? -1 : nums[0];
        }

        public int GetRear()
        {
            return nums.Count == 0 ? -1 : nums[^1];
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
