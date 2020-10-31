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
            public ListNode InsertionSortList(ListNode head)
            {
                if (head == null) return null;
                ListNode dummy = new ListNode(0, head), cur = head;
                while (cur.next != null)
                {
                    if (cur.val < cur.next.val)
                        cur = cur.next;
                    else
                    {
                        var temp = cur.next;
                        cur.next = temp.next;
                        var pos = dummy;
                        while (pos.next.val < temp.val)
                            pos = pos.next;
                        temp.next = pos.next;
                        pos.next = temp;
                    }
                }
                return dummy.next;
            }
        }
    }
}
