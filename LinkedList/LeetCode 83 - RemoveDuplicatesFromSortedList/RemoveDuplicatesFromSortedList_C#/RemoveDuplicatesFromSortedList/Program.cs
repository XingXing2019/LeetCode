//设置两个指针：res和point。当point的值不等于res值时，连接res与point。
using System;

namespace RemoveDuplicatesFromSortedList
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
        static ListNode DeleteDuplicates(ListNode head)
        {
            if (head == null) return null;
            ListNode pre = head, pointer = head.next;
            while (pointer != null)
            {
                if (pointer.val != pre.val)
                {
                    pre.next = pointer;
                    pre = pre.next;
                }
                pointer = pointer.next;
            }
            pre.next = pointer;
            return head;
        }
    }
}
