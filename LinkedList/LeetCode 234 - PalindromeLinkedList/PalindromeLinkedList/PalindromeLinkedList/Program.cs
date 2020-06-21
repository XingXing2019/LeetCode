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
            ListNode reverse = null, point = head;
            while (point != null)
            {
                reverse = new ListNode(point.val) {next = reverse};
                point = point.next;
            }
            while (head != null)
            {
                if (head.val != reverse.val)
                    return false;
                head = head.next;
                reverse = reverse.next;
            }
            return true;
        }
    }
}
