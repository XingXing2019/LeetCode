//计算链表长度，遍历至链表末尾，将链表连成环形链表。
//反向遍历环形链表得到目标尾结点结点。设置其下一节点为目标头结点，断开他们之间的连接。
//当链表长度小于翻转次数时，注意取模避免异常。
using System;

namespace RotateList
{
    class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
    class Program
    {
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
        static void Main(string[] args)
        {

        }
        static ListNode RotateRigth(ListNode head, int k)
        {
            if (head == null)
            {
                return null;
            }
            else
            {
                int len = GetLen(head);
                ListNode point = head;
                for (int i = 0; i < len - 1; i++)
                {
                    point = point.next;
                }
                point.next = head;
                for (int i = 0; i < len - k % len - 1; i++)
                {
                    head = head.next;
                }
                ListNode res = head.next;
                head.next = null;
                return res;
            }
        }
    }
}
