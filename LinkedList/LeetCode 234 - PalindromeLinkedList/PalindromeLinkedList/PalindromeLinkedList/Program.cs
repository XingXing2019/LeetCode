using System;

namespace PalindromeLinkedList
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
        static bool IsPalindrome(ListNode head)
        {
            ListNode reversed = null;
            ListNode point = head;
            bool res = true;
            while (point != null)
            {
                reversed = new ListNode(point.val) { next = reversed };
                point = point.next;
            }
            while (head != null)
            {
                if (head.val != reversed.val)
                    res = false;
                head = head.next;
                reversed = reversed.next;
            }
            return res;
        }
    }
}
