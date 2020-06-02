//设置一个dummyHead指针，dummyHead.next指向head。设置一个point指针指向head。
//让point遍历链表，如果point.next大于point，则point前进一位。
//否则遍历dummyHead，找到第一个比point.next大的节点，将point.next连接到该节点前。
//需利用tem代指point.next，q代指dummyHead以简化代码。
using System;

namespace InsertionSortList
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
        static ListNode InsertionSortList(ListNode head)
        {
            if (head == null)
                return head;
            ListNode dummyHead = new ListNode(0);
            dummyHead.next = head;
            ListNode point = head;
            while (point.next != null)
            {
                if (point.val <= point.next.val)
                    point = point.next;
                else
                {
                    ListNode tem = point.next;
                    ListNode q = dummyHead;
                    point.next = point.next.next;
                    while (q.next.val < tem.val)
                        q = q.next;
                    tem.next = q.next;
                    q.next = tem;
                }
            }
            return dummyHead.next;
        }
    }
}
