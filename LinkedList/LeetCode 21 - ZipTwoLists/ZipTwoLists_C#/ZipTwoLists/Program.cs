//设置拉链节点，遍历两个链表，将较小的节点连接到拉链节点上。
//将较长链表的剩余部分接到拉链尾端。
using System;

namespace ZipTwoLists
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

        }
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            ListNode res = new ListNode(0), point = res;
            while (l1 != null && l2 != null)
            {
                if (l1.val > l2.val)
                {
                    point.next = l2;
                    l2 = l2.next;
                }
                else
                {
                    point.next = l1;
                    l1 = l1.next;
                }
                point = point.next;
            }
            point.next = l1 ?? l2;
            return res.next;
        }
        public ListNode MergeTwoLists_Recursion(ListNode l1, ListNode l2)
        {
            if (l1 == null) return l2;
            if (l2 == null) return l1;
            if (l1.val < l2.val)
            {
                l1.next = MergeTwoLists_Recursion(l1.next, l2);
                return l1;
            }
            l2.next = MergeTwoLists_Recursion(l1, l2.next);
            return l2;
        }
    }
}
