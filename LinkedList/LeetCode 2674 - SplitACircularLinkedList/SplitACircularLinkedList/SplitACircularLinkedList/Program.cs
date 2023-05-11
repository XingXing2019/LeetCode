using System;
using System.Collections.Generic;

namespace SplitACircularLinkedList
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode() { }
        public ListNode(int val) { this.val = val; }
        public ListNode(int val, ListNode next) { this.val = val; this.next = next; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var list = Generate(new[] { 1, 5, 7 });
            Console.WriteLine(SplitCircularLinkedList(list));
        }

        public static ListNode[] SplitCircularLinkedList(ListNode list)
        {
            var visited = false;
            ListNode slowPre = new ListNode(0, list), fastPre = new ListNode(0, list);
            ListNode slow = list, fast = list;
            while (!visited)
            {
                slowPre = slowPre.next;
                slow = slow.next;
                for (int i = 0; i < 2 && !visited; i++)
                {
                    fastPre = fastPre.next;
                    fast = fast.next;
                    if (fast == list) visited = true;
                }
            }
            fastPre.next = slow;
            slowPre.next = list;
            return new ListNode[] { list, slow };
        }

        public static ListNode Generate(int[] nums)
        {
            ListNode res = null, last = null;
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                res = new ListNode(nums[i], res);
                if (i == nums.Length - 1) last = res;
            }
            last.next = res;
            return res;
        }
    }
}
