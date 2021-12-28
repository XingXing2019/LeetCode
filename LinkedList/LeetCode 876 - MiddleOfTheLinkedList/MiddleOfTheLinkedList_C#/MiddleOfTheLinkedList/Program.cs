using System;

namespace MiddleOfTheLinkedList
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

        }
       
        static ListNode MiddleNode(ListNode head)
        {
            ListNode fast = head;
            ListNode slow = head;
            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next;
                fast = fast.next;
            }
            return slow;
        }
    }
}
