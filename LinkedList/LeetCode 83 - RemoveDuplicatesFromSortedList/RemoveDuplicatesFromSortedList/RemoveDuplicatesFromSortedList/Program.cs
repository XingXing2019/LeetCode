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
            ListNode dummy = new ListNode(0);
            ListNode res = head;
            dummy.next = res;
            if (head != null)
            {
                ListNode point = head.next;
                while (point != null)
                {
                    if (res.val != point.val)
                    {
                        res.next = point;
                        res = res.next;
                        point = point.next;
                    }
                    else
                    {
                        point = point.next;
                        res.next = point;
                    } 
                }
                return dummy.next;
            }
            else
                return null;
        }
    }
}
