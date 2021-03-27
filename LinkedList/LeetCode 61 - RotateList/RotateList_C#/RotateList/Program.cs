//计算链表长度，遍历至链表末尾，将链表连成环形链表。
//反向遍历环形链表得到目标尾结点结点。设置其下一节点为目标头结点，断开他们之间的连接。
//当链表长度小于翻转次数时，注意取模避免异常。
using System;
using System.Collections.Generic;

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
            if (head == null) return null;
            var pointer = head;
            int count = 0;
            while (pointer.next != null)
            {
                pointer = pointer.next;
                count++;
            }
            k %= count + 1;
            if (k == 0) return head;
            count -= k;
            var dummy = head;
            for (int i = 0; i < count; i++)
                dummy = dummy.next;
            var res = dummy.next;
            dummy.next = null;
            pointer.next = head;
            return res;
        }
        public ListNode RotateRight_List(ListNode head, int k)
        {
            if (head == null || k == 0) return head;
            var nodes = new List<ListNode>();
            while (head != null)
            {
                nodes.Add(head);
                head = head.next;
            }
            k %= nodes.Count;
            if (k == 0 || nodes.Count == 1) return nodes[0];
            nodes[^1].next = nodes[0];
            nodes[nodes.Count - k - 1].next = null;
            return nodes[nodes.Count - k];
        }
    }
}
