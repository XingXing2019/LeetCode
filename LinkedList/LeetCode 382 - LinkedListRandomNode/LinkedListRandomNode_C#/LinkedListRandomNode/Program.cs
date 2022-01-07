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
            var head = Generate(new[] {1, 2, 3});
            var s = new Solution(head);
            s.GetRandom();
        }

        static ListNode Generate(int[] nums)
        {
            ListNode res = null;
            for (int i = nums.Length - 1; i >= 0; i--)
                res = new ListNode(nums[i], res);
            return res;
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
            var dummy = _head.next;
            int count = 1, res = _head.val;
            while (dummy != null)
            {
                count++;
                if (_random.Next(count) == 0)
                    res = dummy.val;
                dummy = dummy.next;
            }
            return res;
        }
    }


}
