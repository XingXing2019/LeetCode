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
    public class MyCircularQueue1
    {
        private List<int> nums;
        private int capacity;
        public MyCircularQueue1(int k)
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

    public class MyCircularQueue
    {
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val)
            {
                this.val = val;
            }
        }

        public ListNode front;
        public ListNode rear;
        public int size;
        public int k;
        public MyCircularQueue(int k)
        {
            size = k;
            this.k = k;
        }

        public bool EnQueue(int value)
        {
            if (size == 0) return false;
            if (front == null)
            {
                front = new ListNode(value);
                rear = front;
            }
            else
            {
                rear.next = new ListNode(value);
                rear = rear.next;
            }
            size--;
            return true;
        }

        public bool DeQueue()
        {
            if (front != null)
            {
                front = front.next;
                if (front == null)
                    rear = null;
                size++;
                return true;
            }
            return false;
        }

        public int Front()
        {
            return front == null ? -1 : front.val;
        }

        public int Rear()
        {
            return rear == null ? -1 : rear.val;
        }

        public bool IsEmpty()
        {
            return size == k;
        }

        public bool IsFull()
        {
            return size == 0;
        }
    }

}
