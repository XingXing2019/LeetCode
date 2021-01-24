using System;
using System.Collections.Generic;

namespace RemoveLinkedListElements
{
    class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static ListNode RemoveElements(ListNode head, int val)
        {
            ListNode res = new ListNode(0);
            ListNode slow = res;
            ListNode fast = head;
            while (fast != null)
            {
                if (fast.val != val)
                {
                    slow.next = fast;
                    slow = slow.next;
                    fast = fast.next;
                }
                else
                    fast = fast.next;
            }
            slow.next = null;
            return res.next;
        }
        public ListNode RemoveElements_List(ListNode head, int val)
        {
            var nodes = new List<ListNode>();
            while (head != null)
            {
                if (head.val != val)
                    nodes.Add(head);
                head = head.next;
            }
            for (int i = 0; i < nodes.Count; i++)
                nodes[i].next = i == nodes.Count - 1 ? null : nodes[i + 1];
            return nodes.Count == 0 ? null : nodes[0];
        }
    }
}
