//计算链表长度。设置point指针，遍历找到第N个节点，使head指向该节点，point指向其前一节点。
//人为使head向前跳动一节点，将point节点连接此时的head节点。
using System;

namespace RemoveNthNodeFromEndOfList
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
        static ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            var pointer = head;
            int count = 0;
            while (pointer != null)
            {
                count++;
                pointer = pointer.next;
            }
            if (count == n) return head.next;
            count -= n + 1;
            pointer = head;
            while (count > 0)
            {
                pointer = pointer.next;
                count--;
            }
            pointer.next = pointer.next.next;
            return head;
        }
    }
}
