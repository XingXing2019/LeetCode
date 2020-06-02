//设置三个指针：dummy，pre和point。遍历链表，只有到point指针的值和其前后指针都不相等时，连接dummy指针和point指针。
//当point.next为空时停止遍历。人为检查是否连接最后一个节点。
using System;

namespace RemoveDuplicatesFromSortedListII
{
    public class ListNode
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
            if (head != null)
            {
                ListNode res = new ListNode(int.MaxValue);
                ListNode pre = res;
                pre.next = head;
                ListNode point = head;
                ListNode dummy = res;
                while (point.next != null)
                {
                    if (point.val != pre.val && point.val != point.next.val)
                    {
                        dummy.next = point;
                        dummy = dummy.next;
                    }
                    point = point.next;
                    pre = pre.next;
                }
                if (point.val != pre.val)
                    dummy.next = point;
                else
                    dummy.next = null;
                return res.next;
            }
            else
                return null;
        }
    }
}
