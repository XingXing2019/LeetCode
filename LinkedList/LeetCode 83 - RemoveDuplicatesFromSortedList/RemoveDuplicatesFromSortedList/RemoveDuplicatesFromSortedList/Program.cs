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
            ListNode res = head, point = head;
            while (head != null)
            {
                int val = head.val;
                while (head != null && head.val == val)
                    head = head.next;
                point.next = head;
                point = point.next;
            }
            return res;
        }
    }
}
