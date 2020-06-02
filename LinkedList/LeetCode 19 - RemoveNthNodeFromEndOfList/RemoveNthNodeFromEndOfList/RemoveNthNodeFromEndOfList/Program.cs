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
        static int GetLen(ListNode head)
        {
            int len = 0;
            while (head != null)
            {
                len++;
                head = head.next;
            }
            return len;
        }
        static ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            ListNode point = new ListNode(0);
            ListNode dummy = point;
            int len = GetLen(head);
            for (int i = 0; i < len - n; i++)
            {
                point.next = head;
                head = head.next;
                point = point.next;
            }
            head = head.next;
            point.next = head;
            return dummy.next;
        }
    }
}
