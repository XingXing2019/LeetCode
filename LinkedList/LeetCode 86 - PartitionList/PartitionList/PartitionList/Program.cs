//设置more、moreHead和less、lessHead指针，遍历链表把大于或等于给定值的节点连接到more上，小于给定值的节点连接到less上。
//将null连接到more的尾结点。将lessHead和moreHead连接到一起。
using System;

namespace PartitionList
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

        static ListNode Partition(ListNode head, int x)
        {
            ListNode more = new ListNode(0);
            ListNode moreHead = more;
            ListNode less = new ListNode(0);
            ListNode lessHead = less;
            while (head != null)
            {
                if (head.val >= x)
                {
                    more.next = head;
                    more = more.next;
                }
                else
                {
                    less.next = head;
                    less = less.next;
                }
                head = head.next;
            }
            more.next = null;
            less.next = moreHead.next;
            return lessHead.next;
        }
    }
}
