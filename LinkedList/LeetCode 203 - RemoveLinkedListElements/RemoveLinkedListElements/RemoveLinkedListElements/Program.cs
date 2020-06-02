using System;

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
    }
}
