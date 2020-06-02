using System;

namespace LinkedListRandomNode
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    public class Solution
    {
        private readonly ListNode _head;
        private Random _random;

        public Solution(ListNode head)
        {
            _head = head;
            _random = new Random();
        }
        public int GetRandom()
        {
            var dummy = _head;
            int count = 0;
            int res = -1;
            while (dummy != null)
            {
                if (_random.Next(++count) == 0)
                    res = dummy.val;
                dummy = dummy.next;
            }
            return res;
        }
    }

}
