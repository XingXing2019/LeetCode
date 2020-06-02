//设置拉链节点，遍历两个链表，将较小的节点连接到拉链节点上。
//将较长链表的剩余部分接到拉链尾端。
using System;

namespace ZipTwoLists
{
    class ListNode
    {
        public int val;
        public ListNode next;
    }
    class Program
    {
        static void Main(string[] args)
        {
            ListNode list1 = MakeList(new int[] { 1, 3, 5, 7, 7, 9 });
            ListNode list2 = MakeList(new int[] { 2, 6, 7, 8 });

            ListNode res = Zip(list1, list2);
            PrintList(res);
        }

        static ListNode Zip(ListNode p, ListNode q)
        {
            //dummy head
            ListNode zipper = new ListNode();
            ListNode head = zipper;
            while (p != null && q != null)
            {
                if (p.val <= q.val)
                {
                    zipper.next = p;
                    p = p.next;
                }
                else
                {
                    zipper.next = q;
                    q = q.next;
                }
                zipper = zipper.next;
            }
            zipper.next = p == null ? q : p;
            return head.next;
        }

        static ListNode MakeList(int[] a)
        {
            ListNode head = null;
            for (int i = a.Length - 1; i >= 0; i--)
            {
                head = new ListNode() { val = a[i], next = head };
            }
            return head;
        }
        static void PrintList(ListNode list)
        {
            while (list != null)
            {
                Console.Write($"{list.val} -> ");
                list = list.next;
            }
            Console.WriteLine("null");
        }
    }
}
