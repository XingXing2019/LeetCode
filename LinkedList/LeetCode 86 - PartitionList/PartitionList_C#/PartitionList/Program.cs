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
            ListNode smallHead = new ListNode(), largeHear = new ListNode();
            ListNode pointS = smallHead, pointL = largeHear;
            while (head != null)
            {
                if (head.val < x)
                {
                    pointS.next = head;
                    pointS = pointS.next;
                }
                else
                {
                    pointL.next = head;
                    pointL = pointL.next;
                }
                head = head.next;
            }
            pointL.next = null;
            pointS.next = largeHear.next;
            return smallHead.next;
        }
    }
}
